using Neo.Domain.Features.Client;
using Neo.Endpoint;
using Club.CustomerPortal.Application.Interfaces;
using Club.Infrastructure.Data.Repository.Club;

namespace Club.CustomerPortal.Api;

public static class DependencyInjection
{
    private static IConfiguration? _configuration;
    
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;
        
        services.AddHttpContextAccessor();
        services.AddScoped<IRequesterUser, CustomerRequesterUser>();
        services.AddScoped<ICustomerRequesterUser, CustomerRequesterUser>();
        services.AddCandoControllerServices("Club Customer Portal API");

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHealthChecks()
            .AddDbContextCheck<ClubContextCommand>()
            .AddDbContextCheck<ClubContextQuery>();

        // Configure CORS for Customer Portal
        services.AddCors(options =>
        {
            options.AddPolicy("AllowCustomerPortal", policy =>
            {
                var origins = _configuration?.GetSection("CustomerPortal:AllowedOrigins").Value?.Split(',') 
                    ?? new[] { "http://localhost:3000" };
                policy.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}
