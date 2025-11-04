using Neo.Domain.Features.Client;
using Neo.Endpoint;
using Club.Infrastructure.Data.Repository.Club;

namespace Club.Channel.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IRequesterUser, RequesterUser>();
        services.AddCandoControllerServices("Club API");

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHealthChecks()
            .AddDbContextCheck<ClubContextCommand>()
            .AddDbContextCheck<ClubContextQuery>();
        return services;
    }
}
