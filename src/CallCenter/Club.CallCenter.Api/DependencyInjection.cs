using Club.Infrastructure.Data.Repository.Club;
using Neo.Domain.Features.Client;
using Neo.Endpoint;

namespace Club.CallCenter.Api;

public static class DependencyInjection
{
    private static IConfiguration? _configuration;

    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;

        services.AddHttpContextAccessor();
        services.AddScoped<IRequesterUser, CallCenterRequesterUser>();
        services.AddNeoControllerServices(configuration, "Club Call Center API");

        services.AddHealthChecks()
            .AddDbContextCheck<ClubContextCommand>()
            .AddDbContextCheck<ClubContextQuery>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowCallCenter", policy =>
            {
                var origins = _configuration?.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? ["http://localhost:3001"];
                policy.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}

