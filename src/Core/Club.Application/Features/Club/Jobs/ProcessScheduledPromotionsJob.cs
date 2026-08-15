using Club.Domain.Features.Promotions;

namespace Club.Application.Features.Club.Jobs;

/// <summary>
/// پیاده‌سازی Job برای اجرای پویش‌های زمان‌بندی شده
/// </summary>
public class ProcessScheduledPromotionsJob(
    IPromotionService promotionService,
    ILogger<ProcessScheduledPromotionsJob> logger
    ) : IProcessScheduledPromotionsJob
{
    public async Task Run()
    {
        logger.LogInformation("Starting scheduled promotions processing at {Time}", DateTime.UtcNow);

        try
        {
            await promotionService.ProcessScheduledPromotions(CancellationToken.None);
            logger.LogInformation("Completed scheduled promotions processing at {Time}", DateTime.UtcNow);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing scheduled promotions at {Time}", DateTime.UtcNow);
            throw;
        }
    }
}

