using Club.Channel.Application.Features.Channel.Commands;
using FluentValidation;

namespace Club.Channel.Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddChannelApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var applicationAssembly = typeof(EnqueueChannelEventCommand).Assembly;
        
        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(applicationAssembly);
        });

        return services;
    }
}