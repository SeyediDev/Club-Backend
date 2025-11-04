namespace Club.Domain.Features;

public interface IPromotionService
{
    /// <summary>
    /// اجرای پویش‌های زمان‌بندی شده
    /// </summary>
    [Telemetry]
    Task ProcessScheduledPromotions(CancellationToken cancellationToken);
}

internal class PromotionService(
    ILogger<PromotionService> logger,
    IQueryRepository<Promotion, int> promotionRepo,
    ICommandRepository<PromotionMessage, int> messageRepo,
    ICommandRepository<PromotionRecipient, int> recipientRepo,
    IQueryRepository<CustomerSegmentMembership, int> segmentMembershipRepo
    ) : IPromotionService
{
    public async Task ProcessScheduledPromotions(CancellationToken cancellationToken)
    {
        DateTime now = DateTime.Now;

        // Get active scheduled promotions
        var allPromotions = await promotionRepo.GetAllAsync(cancellationToken);
        var scheduledPromotions = allPromotions
            .Where(p => p.IsScheduled
                    && p.PromotionSchedulingKind.HasValue
                    && (p.FromDate == null || p.FromDate <= now)
                    && (p.ToDate == null || p.ToDate >= now))
            .ToList();

        logger.LogInformation("Found {Count} scheduled promotions to evaluate", scheduledPromotions.Count);

        foreach (var promotion in scheduledPromotions)
        {
            try
            {
                // Check if it's time to run this promotion
                if (ShouldRunPromotion(promotion, now))
                {
                    logger.LogInformation("Executing scheduled promotion: {PromotionId} - {PromotionTitle}", 
                        promotion.Id, promotion.Title);
                    await ExecuteScheduledPromotion(promotion, now, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing scheduled promotion {PromotionId}", promotion.Id);
            }
        }
    }

    private bool ShouldRunPromotion(Promotion promotion, DateTime now)
    {
        if (!promotion.IsScheduled || !promotion.PromotionSchedulingKind.HasValue)
            return false;

        // Check hour and minute if specified
        if (promotion.ScheduledHour.HasValue && now.Hour != promotion.ScheduledHour.Value)
            return false;

        if (promotion.ScheduledMinute.HasValue && now.Minute != promotion.ScheduledMinute.Value)
            return false;

        return promotion.PromotionSchedulingKind switch
        {
            Entities.Promotions.SchedulingKind.Daily => true, // Run every day at specified time
            Entities.Promotions.SchedulingKind.Weekly => promotion.WeekDay.HasValue && now.DayOfWeek == promotion.WeekDay.Value,
            Entities.Promotions.SchedulingKind.Monthly => promotion.MonthDay.HasValue && now.Day == promotion.MonthDay.Value,
            Entities.Promotions.SchedulingKind.Yearly => promotion.MonthDay.HasValue 
                                    && promotion.ScheduledMonth.HasValue 
                                    && now.Day == promotion.MonthDay.Value
                                    && now.Month == promotion.ScheduledMonth.Value,
            _ => false
        };
    }

    private async Task ExecuteScheduledPromotion(Promotion promotion, DateTime now, CancellationToken cancellationToken)
    {
        logger.LogInformation("Executing promotion {PromotionId}: {Title}", promotion.Id, promotion.Title);

        // Get customers in target segment via membership
        var allMemberships = await segmentMembershipRepo.GetAllAsync(cancellationToken);
        var segmentMemberships = allMemberships
            .Where(m => m.SegmentId == promotion.CustomerSegmentId)
            .ToList();

        if (!segmentMemberships.Any())
        {
            logger.LogWarning("No customers found for promotion {PromotionId} in segment {SegmentId}", 
                promotion.Id, promotion.CustomerSegmentId);
            return;
        }

        logger.LogInformation("Found {CustomerCount} customers in segment {SegmentId} for promotion {PromotionId}",
            segmentMemberships.Count, promotion.CustomerSegmentId, promotion.Id);

        // Create promotion message
        PromotionMessage message = new()
        {
            PromotionId = promotion.Id,
            Subject = $"پیام پویش: {promotion.Title}",
            Content = $"شما مشمول پویش {promotion.Title} هستید",
            Type = PromotionMessageType.Informational,
            Status = PromotionMessageStatus.Sent,
            Priority = 1,
            ScheduledTime = now,
            SentDate = now
        };
        messageRepo.Add(message);
        await messageRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        // Create recipients for all customers in segment
        int recipientCount = 0;
        foreach (var membership in segmentMemberships)
        {
            try
            {
                PromotionRecipient recipient = new()
                {
                    PromotionId = promotion.Id,
                    CustomerId = membership.CustomerId,
                    Status = PromotionRecipientStatus.Sent,
                    SentDate = now
                };
                recipientRepo.Add(recipient);
                recipientCount++;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating recipient for customer {CustomerId} in promotion {PromotionId}",
                    membership.CustomerId, promotion.Id);
            }
        }

        await recipientRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Created {RecipientCount} recipients for promotion {PromotionId}",
            recipientCount, promotion.Id);

        // Update message counts
        message.SentCount = recipientCount;
        message.DeliveredCount = recipientCount;
        messageRepo.Update(message);
        await messageRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Successfully executed scheduled promotion {PromotionId}", promotion.Id);
    }
}

