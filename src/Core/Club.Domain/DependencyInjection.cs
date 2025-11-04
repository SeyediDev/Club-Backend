using Neo.Domain;
using Neo.Domain.Features.Client;
using Club.Domain.Features;
using Club.Domain.Features.Client;
using Club.Domain.Features.ScoringRules;
using Microsoft.Extensions.Configuration;

namespace Club.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddClubDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCandoDomainServices(configuration);
        services.AddScoped<IAwardAssetService, AwardAssetService>();
        services.AddScoped<IAwardAssetInternalService, AwardAssetInternalService>();
        services.AddScoped<IProductOrServiceService, ProductOrServiceService>();
        services.AddScoped<ILotteryService, LotteryService>();
        services.AddScoped<IPromotionService, PromotionService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IScoringRuleService, ScoringRuleService>();
        services.AddScoped<IScoringRuleActionService, ScoringRuleActionService>();
        services.AddScoped<ISerialGenerator, SerialGenerator>();
        services.AddScoped<IAwardService, AwardService>();
        services.AddScoped<IPointBudgetService, PointBudgetService>();
        services.AddScoped<IPointLevelService, PointLevelService>();
        services.AddScoped<IPointTransferService, PointTransferService>();
        services.AddScoped<IEvaluateFormulaService, EvaluateFormulaService>();
        services.AddScoped<ICustomerSegmentService, CustomerSegmentService>();
        
        services.AddScoped<ILoginUserService<int>, LoginUserService>();
        return services;
    }
}
