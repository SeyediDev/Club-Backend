using Neo.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Club.CustomerPortal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddCustomerPortalApplicationServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddCandoApplicationServices(
            configuration, 
            typeof(DependencyInjection).Assembly);
        
        // Register Mock Service implementations for testing
        // TODO: Replace with real implementations from Infrastructure layer
        services.AddScoped<ICustomerService, Services.MockCustomerService>();
        services.AddScoped<IAuthenticationService, Services.MockAuthenticationService>();
        services.AddScoped<IPointService, Services.MockPointService>();
        services.AddScoped<IRewardService, Services.MockRewardService>();
        services.AddScoped<IReferralService, Services.MockReferralService>();
        services.AddScoped<IPromotionService, Services.MockPromotionService>();
        services.AddScoped<ILotteryService, Services.MockLotteryService>();
        services.AddScoped<ISurveyService, Services.MockSurveyService>();
        services.AddScoped<IDashboardService, Services.MockDashboardService>();
        
        return services;
    }
}


