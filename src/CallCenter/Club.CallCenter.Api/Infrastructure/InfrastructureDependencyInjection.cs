using Club.Application;
using Club.CallCenter.Api.Services;
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

namespace Club.CallCenter.Api.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddCallCenterInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddClubDomainServices(configuration);
        services.AddClubApplicationServices(configuration);

        AddCorsPolicy(services, configuration);
		services.AddClubRepositories(configuration);
        services.AddSmsDummyServices(configuration);
        services.AddSingleton<InMemorySmsService>();
        services.AddSingleton<ISmsService>(sp => sp.GetRequiredService<InMemorySmsService>());
        services.AddSingleton<IOtpService>(sp => sp.GetRequiredService<InMemorySmsService>());
        services.AddSingleton<IObjectStoreService, InMemoryObjectStoreService>();
        services.AddSingleton<IJobExecuter, InMemoryJobExecuter>();
        services.AddSingleton<IDistributedLock, InMemoryDistributedLock>();
        services.AddSingleton<IExternalApiService, NoopExternalApiService>();

        services.AddScoped<INeoPublisher, MediatRNeoPublisher>();

        return services;
    }

    private static void AddCorsPolicy(IServiceCollection services, IConfiguration configuration)
    {
        var origins = configuration["Cors:AllowedOrigins"];
        if (origins is null)
        {
            return;
        }

        services.AddCors(options =>
        {
            options.AddPolicy("AllowCallCenter", policy =>
            {
                policy.WithOrigins(origins.Split(','))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }
}

