using Neo.Application;
using Club.Application.Features.Club.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Club.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddClubApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCandoApplicationServices(configuration, typeof(DependencyInjection).Assembly);
        
        // Register recurring jobs
        services.AddScoped<IProcessScheduledLotteriesJob, ProcessScheduledLotteriesJob>();
        services.AddScoped<IProcessScheduledPromotionsJob, ProcessScheduledPromotionsJob>();
        
        return services;
    }
}
