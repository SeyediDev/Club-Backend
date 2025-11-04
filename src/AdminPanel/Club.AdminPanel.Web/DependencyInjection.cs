using Neo.Bpms.Domain;
using Neo.Bpms.Domain.Features.Security;
using Neo.Bpms.Infrastructure;
using Neo.Bpms.UI.MVC;
using Neo.Bpms.UI.MVC.Helpers;
using Neo.Domain.Features.Client;
using Neo.Infrastructure;
using Neo.Infrastructure.Features.Client;
using Neo.Infrastructure.Features.Telementry;
using Club.Application;
using Club.AdminPanel.Domain.Infrastructure;
using Club.AdminPanel.Web.Infrastructure;
using Club.Infrastructure;

namespace Club.AdminPanel.Web;

public static class DependencyInjection
{
    public static void AddClubBpmsServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddClubApplicationServices(configuration);

        services.AddCandoInfrastructureServices(configuration);
        services.AddCandoAuthorization(configuration);
        services.AddCandoOpenTelementry(configuration);
        services.AddCandoBpmsInfrastructure(configuration);

        services.AddClubInfrastructureServices(configuration, environment);

        services.AddClubBpmsInfrastructures(configuration);

        services.AddBpmsMVC(configuration);
        
        // Performance Optimizations: Compression & Caching
        services.AddPerformanceOptimizations();
        
        // Database Caching (با قابلیت غیرفعال‌سازی)
        services.AddDatabaseCaching(configuration);
        
        SpecificCommonlyNeededAssets.SetNeededResources("~/Content/images/login-logo.svg",
            "~/Content/common-assets-includes/icons/svgSprite.svg#club-svg-icon-header");
        
        _ = services.AddScoped<IRequesterUser, RequesterUser>();
        _ = services.AddScoped<IIdentityUserService, IdentityUserService>();
    }

    public static void UseClubBpms(this IApplicationBuilder app, 
        IConfiguration configuration, IHostEnvironment environment, BpmsMVCConfigurationOptions options = null)
    {
        app.UseClub(configuration, environment);
        
        // Performance Optimizations: must be called BEFORE UseBpmsMVC
        // This ensures UseResponseCompression and UseStaticFiles (with caching) are registered first
        app.UsePerformanceOptimizations(environment);
        
        app.UseBpmsMVC(configuration, options);
        DependencyInjectionHolder.Instance.SsoIntegrator = null;//Inject<SsoIntegrator>(app);//FOR SSO
    }
}
