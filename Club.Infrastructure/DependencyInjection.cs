using Ardalis.GuardClauses;
using Neo.Application.Features.Queue;
using Neo.Domain.Features.PubSub;
using Neo.Domain.Repository;
using Neo.Infrastructure;
using Neo.Infrastructure.Features.Cache;
using Neo.Infrastructure.Features.ObjectStore;
using Neo.Infrastructure.Features.Outbox;
using Neo.Infrastructure.Features.Queue.Hangfire;
using Club.Domain;
using Club.Domain.Repository;
using Club.Infrastructure.Configuration;
using Club.Infrastructure.Data.Repository;
using Club.Infrastructure.Data.Repository.Club;
using Club.Infrastructure.Features.Jobs;
using Club.Infrastructure.Features.PubSub;
using Club.Infrastructure.Features.Sms.SmsDummy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace Club.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddClubInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddClubDomainServices(configuration);
        services.AddCandoInfrastructureServices(configuration);
        
        if (environment.IsDevelopment())
        {
            services.AddCandoMemoryCacheServices(configuration);
            services.AddCandoOutboxWithCatch(configuration);
        }
        else
        {
            services.AddCandoRedisCacheServices(configuration);
            services.AddCandoOutboxWithMongo(configuration);
        }
        services.AddCandoMinIo(configuration);
        services.AddCandoHangfire(configuration);

        AddCorsPolicy(services,configuration);
        AddRepositories(services, configuration);
        AddFeatureServices(services, configuration);
        
        services.AddScoped<ICandoPublisher, MediatRCandoPublisher>();
        //AddMassTransitServices(services, configuration);
        //services.AddSignalRServices(configuration);
        return services;
    }

    private static void AddCorsPolicy(IServiceCollection services, IConfiguration configuration)
    {
        var origins = configuration["AllowedOrigins"];
        if (origins is not null)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
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

    private static void AddRepositories(IServiceCollection services, IConfiguration configuration)
    {
        var commandConnectionString = configuration.GetConnectionString($"{nameof(DomainProvider.Domain)}CommandConnection");
        Guard.Against.Null(commandConnectionString, message: $"Connection string '{nameof(DomainProvider.Domain)}CommandConnection' not found.");
        services.AddDbContext<ClubContextCommand>((serviceProvider, options) =>
        {
            options.UseSqlServer(commandConnectionString);
            options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());
        });
        services.AddScoped<IClubUnitOfWorkCommand>(serviceProvider => serviceProvider.GetRequiredService<ClubContextCommand>());

        var queryConnectionString = configuration.GetConnectionString($"{nameof(DomainProvider.Domain)}QueryConnection");
        Guard.Against.Null(queryConnectionString, message: $"Connection string '{nameof(DomainProvider.Domain)}QueryConnection' not found.");
        services.AddDbContextPool<ClubContextQuery>(options => options.UseSqlServer(queryConnectionString)
                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        services.AddScoped<IClubUnitOfWorkQuery>(serviceProvider => serviceProvider.GetRequiredService<ClubContextQuery>());

        services.AddScoped(typeof(ICommandRepository<,>), typeof(CommandClubEntityRepository<,>));
        services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryClubEntityRepository<,>));

        services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<ICultureTermQueryRepository, CultureTermQueryRepository>();
    }

    private static IServiceCollection AddFeatureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(options => configuration.Bind(options));
        services.AddSmsDummyServices(configuration);
        
        // Register Club recurring jobs
        services.AddScoped<IRegisterRecurringJobs, RegisterClubRecurringJobs>();
        
        return services;
    }



    private static IServiceCollection AddSignalRServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSignalR();
        return services;
    }

    public static void UseClub(this IApplicationBuilder app,
        IConfiguration configuration, IHostEnvironment environment)
    {
        app.UseCandoHangfireDashboard(configuration, environment);
    }
}
