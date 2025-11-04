namespace Club.Domain.Features;

/// <summary>
/// سرویس قرعه‌کشی - مدیریت قرعه‌کشی‌های چرخونه و زمان‌بندی شده
/// </summary>
public interface ILotteryService
{
    [Telemetry]
    Task<SpinLotteryResponse> SpinLottery(SpinLotteryRequest request, CancellationToken cancellationToken);

    [Telemetry]
    Task ProcessScheduledLotteries(CancellationToken cancellationToken);
}

public record SpinLotteryRequest
{
    public int LotteryId { get; set; }
    public string CustomerId { get; set; } = null!;
}

public record SpinLotteryResponse
{
    public int ParticipantId { get; set; }
    public bool IsWinner { get; set; }
    public int? AwardId { get; set; }
    public int? AwardAmount { get; set; }
    public string? Message { get; set; }
}

internal class LotteryService(
    ILogger<LotteryService> logger,
    ICustomerService customerService,
    IAwardAssetInternalService awardAssetInternalService,
    IQueryRepository<Lottery, int> lotteryRepo,
    IQueryRepository<LotteryReward, int> lotteryRewardRepo,
    ICommandRepository<LotteryParticipant, int> participantRepo
    ) : ILotteryService
{
    /// <summary>
    /// اجرای روتین قرعه‌کشی چرخونه - کاربر درخواست می‌دهد و فوراً قرعه‌کشی می‌شود
    /// </summary>
    public async Task<SpinLotteryResponse> SpinLottery(SpinLotteryRequest request, CancellationToken cancellationToken)
    {
        // Get lottery
        Lottery? lottery = await lotteryRepo.FirstOrDefaultAsync(
            x => x.Id == request.LotteryId, cancellationToken)
            ?? throw new NullReferenceException("قرعه‌کشی یافت نشد");

        // Validate lottery is active and within date range
        if (lottery.FromDate.HasValue && lottery.FromDate > DateTime.Now)
            throw new InvalidOperationException("قرعه‌کشی هنوز آغاز نشده است");
        
        if (lottery.ToDate.HasValue && lottery.ToDate < DateTime.Now)
            throw new InvalidOperationException("قرعه‌کشی به پایان رسیده است");

        // Check if lottery is wheel type
        if (lottery.LotteryType != LotteryType.Wheel)
            throw new InvalidOperationException("این قرعه‌کشی از نوع چرخونه نیست");

        // Get customer
        Customer? customer = await customerService.GetCustomer(request.CustomerId, false, null, cancellationToken)
            ?? throw new NullReferenceException("مشتری یافت نشد");

        // Check if customer is in segment (if specified)
        // TODO: Implement segment validation if needed
        // For now, we skip this check as it requires additional repository setup
        
        // Check if customer has already participated (optional - depends on business logic)
        var existingParticipant = await participantRepo.FirstOrDefaultAsync(
            x => x.LotteryId == lottery.Id && x.CustomerId == customer.Id, cancellationToken);
        
        // For now, we allow multiple participations - adjust based on requirements

        // Get active rewards for this lottery
        var allRewards = await lotteryRewardRepo.GetAllAsync(cancellationToken);
        var rewards = allRewards
            .Where(x => x.LotteryId == lottery.Id && x.IsActive && x.CanDistribute)
            .ToList();

        if (!rewards.Any())
            throw new InvalidOperationException("هیچ پاداش فعالی در این قرعه‌کشی وجود ندارد");

        // Select winning reward based on probability
        LotteryReward? winningReward = SelectWinningReward(rewards);

        // Create participant record
        LotteryParticipant participant = new()
        {
            LotteryId = lottery.Id,
            CustomerId = customer.Id,
            IsWinner = winningReward != null,
            AwardId = winningReward?.AwardId,
            AwardAmount = winningReward?.Amount,
            ParticipatedAt = DateTime.Now
        };

        participantRepo.Add(participant);
        await participantRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        // If winner, distribute award
        if (winningReward != null && winningReward.CanDistribute)
        {
            // Update distributed count
            winningReward.DistributedCount++;
            
            // Create AwardAsset for winner if applicable
            if (winningReward.Award != null)
            {
                try
                {
                    var awardAssets = await awardAssetInternalService.Create(
                        winningReward.Award,
                        customer,
                        null, // eventLogId - can be linked later
                        null, // ruleId
                        null, // actionId
                        winningReward.Amount,
                        cancellationToken);
                    
                    if (awardAssets.Any())
                    {
                        participant.AwardAssetId = awardAssets.First().Id;
                        participant.IsAwardDistributed = true;
                        participant.AwardDistributedAt = DateTime.Now;
                    }
                    
                    logger.LogInformation("Award distributed to lottery winner: {CustomerId}, Award: {AwardId}, Quantity: {Amount}",
                        customer.Id, winningReward.AwardId, winningReward.Amount);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to distribute award to lottery winner");
                    // Don't fail the entire process
                }
            }

            await participantRepo.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        return new SpinLotteryResponse
        {
            ParticipantId = participant.Id,
            IsWinner = winningReward != null,
            AwardId = winningReward?.AwardId,
            AwardAmount = winningReward?.Amount,
            Message = winningReward != null && winningReward.Award != null ? $"تبریک! شما برنده شدید: {winningReward.Award.Title}" : "متأسفانه این بار برنده نشدید"
        };
    }

    /// <summary>
    /// انتخاب پاداش برنده بر اساس احتمال (WinRate)
    /// </summary>
    private LotteryReward? SelectWinningReward(List<LotteryReward> rewards)
    {
        // Calculate total probability space
        int totalProbability = rewards.Sum(r => r.WinRate);
        
        // Generate random number
        Random random = new();
        int randomValue = random.Next(1, totalProbability + 1);

        // Find winning reward
        int cumulativeProbability = 0;
        foreach (var reward in rewards)
        {
            cumulativeProbability += reward.WinRate;
            if (randomValue <= cumulativeProbability)
            {
                return reward;
            }
        }

        return null; // No winner (based on probabilities)
    }

    /// <summary>
    /// پردازش قرعه‌کشی‌های زمان‌بندی شده
    /// این متد باید به صورت scheduled job اجرا شود
    /// </summary>
    public async Task ProcessScheduledLotteries(CancellationToken cancellationToken)
    {
        DateTime now = DateTime.Now;
        
        // Get active scheduled lotteries
        var allLotteries = await lotteryRepo.GetAllAsync(cancellationToken);
        var scheduledLotteries = allLotteries
            .Where(l => l.LotteryType == LotteryType.Scheduled 
                    && l.IsScheduled 
                    && (l.FromDate == null || l.FromDate <= now)
                    && (l.ToDate == null || l.ToDate >= now))
            .ToList();

        foreach (var lottery in scheduledLotteries)
        {
            // Check if it's time to run this lottery
            if (ShouldRunLottery(lottery, now))
            {
                try
                {
                    await ExecuteScheduledLottery(lottery, now, cancellationToken);
                    logger.LogInformation("Executed scheduled lottery: {LotteryId}", lottery.Id);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to execute scheduled lottery: {LotteryId}", lottery.Id);
                }
            }
        }
    }

    /// <summary>
    /// بررسی اینکه آیا قرعه‌کشی باید اجرا شود
    /// </summary>
    private bool ShouldRunLottery(Lottery lottery, DateTime now)
    {
        if (!lottery.IsScheduled || !lottery.SchedulingKind.HasValue)
            return false;

        return lottery.SchedulingKind switch
        {
            Entities.Promotions.SchedulingKind.Daily => true, // Run every day
            Entities.Promotions.SchedulingKind.Weekly => lottery.DayOfWeek.HasValue && (int)now.DayOfWeek == lottery.DayOfWeek,
            Entities.Promotions.SchedulingKind.Monthly => lottery.DayOfMonth.HasValue && now.Day == lottery.DayOfMonth,
            Entities.Promotions.SchedulingKind.Yearly => lottery.DayOfYear.HasValue && now.DayOfYear == lottery.DayOfYear,
            _ => false
        };
    }

    /// <summary>
    /// اجرای قرعه‌کشی زمان‌بندی شده
    /// </summary>
    private Task ExecuteScheduledLottery(Lottery lottery, DateTime now, CancellationToken cancellationToken)
    {
        // Get all eligible participants (e.g., all customers in segment or all customers)
        // For now, implement based on business requirements
        
        // TODO: Implement logic to select participants and run lottery
        
        logger.LogInformation("Scheduled lottery execution not yet fully implemented");
        return Task.CompletedTask;
    }
}

