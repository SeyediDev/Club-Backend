using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Club.Channel.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddChannelApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}



