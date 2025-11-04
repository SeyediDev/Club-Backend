using Neo.Domain.Features.PubSub;
using MediatR;

namespace Club.Infrastructure.Features.PubSub;

public class MediatRCandoPublisher(IPublisher publisher) : ICandoPublisher
{
    public async Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        await publisher.Publish(message, cancellationToken);
    }
}