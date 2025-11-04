using Microsoft.Extensions.Logging;

namespace Club.Application.Features.Club.Jobs;

/// <summary>
/// پیاده‌سازی Job برای اجرای قرعه‌کشی‌های زمان‌بندی شده
/// </summary>
public class ProcessScheduledLotteriesJob(
    ILotteryService lotteryService,
    ILogger<ProcessScheduledLotteriesJob> logger
    ) : IProcessScheduledLotteriesJob
{
    public async Task Run()
    {
        logger.LogInformation("Starting scheduled lotteries processing at {Time}", DateTime.Now);

        try
        {
            await lotteryService.ProcessScheduledLotteries(CancellationToken.None);
            logger.LogInformation("Completed scheduled lotteries processing at {Time}", DateTime.Now);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing scheduled lotteries at {Time}", DateTime.Now);
            throw;
        }
    }
}

