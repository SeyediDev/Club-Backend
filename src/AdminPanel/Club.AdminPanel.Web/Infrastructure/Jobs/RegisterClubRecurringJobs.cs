using Club.Application.Features.Club.Jobs;
using Club.Application.Features.Points.Jobs;

namespace Club.AdminPanel.Web.Infrastructure.Jobs;

/// <summary>
/// ثبت jobهای دوره‌ای (recurring jobs) سیستم باشگاه
/// این کلاس باید در Application layer استفاده شود
/// </summary>
public class RegisterClubRecurringJobs(
    IRecurringJobsManager recurringJobsManager,
    ILogger<RegisterClubRecurringJobs> logger) : IRegisterRecurringJobs
{
    public void Register()
    {
        logger.LogWarning("Registering recurring jobs is diable. at {Time}", DateTime.UtcNow);
        
        logger.LogInformation("Registering Club recurring jobs at {Time}", DateTime.UtcNow);
        recurringJobsManager.RemoveIfExists<IProcessScheduledLotteriesJob>();
        //recurringJobsManager.AddOrUpdate<IProcessScheduledLotteriesJob>();
        recurringJobsManager.RemoveIfExists<IProcessScheduledPromotionsJob>();
        //recurringJobsManager.AddOrUpdate<IProcessScheduledPromotionsJob>();
        recurringJobsManager.RemoveIfExists<IScheduleLotteriesJob>();
        //recurringJobsManager.AddOrUpdate<IScheduleLotteriesJob>();

        //recurringJobsManager.AddOrUpdate<Club.CustomerPortal.Application.Features.Plans.Jobs.IExpireCustomerPlansJob>();

        recurringJobsManager.RemoveIfExists<IExpirePointsJob>();
        //recurringJobsManager.AddOrUpdate<IExpirePointsJob>();
        // Get job types dynamically from service provider

        logger.LogInformation("Successfully registered all Club recurring jobs");
        
    }
}