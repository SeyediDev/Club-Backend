using Ardalis.GuardClauses;
using Club.Domain.Repository;
using Club.Infrastructure.Configuration;
using Club.Infrastructure.Data.Repository;
using Club.Infrastructure.Data.Repository.Club;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Neo.Domain.Repository;
using Neo.Infrastructure.Features.Queue.Hangfire;
using Quartz;

namespace Club.Infrastructure;

public static class DependencyInjection
{
	public static void AddClubRepositories(this IServiceCollection services, IConfiguration configuration)
	{
		// Initialize Mapster configurations
		_ = typeof(Configuration.AttributeValueMappingConfig);
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

		services.AddScoped(typeof(ICommandRepository<>), typeof(CommandClubEntityRepository<>));
		services.AddScoped(typeof(IQueryRepository<>), typeof(QueryClubEntityRepository<>));
        services.AddScoped(typeof(ICommandRepositoryL<>), typeof(CommandClubEntityRepositoryL<>));
        services.AddScoped(typeof(IQueryRepositoryL<>), typeof(QueryClubEntityRepositoryL<>));
        services.AddScoped(typeof(ICommandRepository<,>), typeof(CommandClubEntityRepository<,>));
		services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryClubEntityRepository<,>));

		services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<ICultureTermQueryRepository, CultureTermQueryRepository>();
    }

    public static void UseClub(this IApplicationBuilder app,
        IConfiguration configuration, IHostEnvironment environment)
    {
        app.UseNeoHangfireDashboard(configuration, environment);
    }
}