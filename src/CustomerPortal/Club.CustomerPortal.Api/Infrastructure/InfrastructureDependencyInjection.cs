using Club.Application;
using Club.CustomerPortal.Api.Services;
using Club.Domain;
using Club.Infrastructure;
using Club.Infrastructure.Features.PubSub;
using Club.Infrastructure.Features.Sms.SmsDummy;
using Neo.Application.Features.Outbox;
using Neo.Application.Features.Queue;
using Neo.Domain.Features.Integrations;
using Neo.Domain.Features.ObjectStore;
using Neo.Domain.Features.PubSub;
using Neo.Domain.Features.Sms;

namespace Club.CustomerPortal.Api.Infrastructure;

/// <summary>
/// Infrastructure services for CustomerPortal.Api
/// CustomerPortal needs: Database (Read/Write), Cache, ObjectStore (for files/images)
/// Similar to Call Center API, using in-memory services for development
/// </summary>
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddCustomerPortalInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        // Core Domain & Application Services
        services.AddClubDomainServices(configuration);
        services.AddClubApplicationServices(configuration);

        // CORS Policy
        AddCorsPolicy(services, configuration);

		// Database & Repositories
		services.AddClubRepositories(configuration);

		// In-memory services for development (similar to Call Center API)
		services.AddSingleton<InMemorySmsService>();
		services.AddSmsDummyServices(configuration);
		services.AddSingleton<ISmsService>(sp => sp.GetRequiredService<InMemorySmsService>());
        services.AddSingleton<IOtpService>(sp => sp.GetRequiredService<InMemorySmsService>());
        services.AddSingleton<IObjectStoreService, InMemoryObjectStoreService>();
        services.AddSingleton<IJobExecuter, InMemoryJobExecuter>();
        services.AddSingleton<IDistributedLock, InMemoryDistributedLock>();
        services.AddSingleton<IRecurringJobsManager, NoOpRecurringJobsManager>();
        services.AddSingleton<IExternalApiService, NoopExternalApiService>();
        
        // Recurring Jobs Registration (No-op for CustomerPortal)
        services.AddScoped<IRegisterRecurringJobs, NoOpRegisterRecurringJobs>();
        
        // Publisher (MediatR)
        services.AddScoped<INeoPublisher, MediatRNeoPublisher>();
        
        return services;
    }

    private static void AddCorsPolicy(IServiceCollection services, IConfiguration configuration)
    {
        var origins = configuration["CustomerPortal:AllowedOrigins"];
        if (origins is not null)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCustomerPortal", policy =>
                {
                    policy
                        .WithOrigins(origins.Split(','))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }
    }
}

