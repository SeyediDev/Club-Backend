using Neo.Domain.Features.PubSub;
using MassTransit;

namespace Club.Infrastructure.Features.PubSub.MassTransit;

public class MassTransitNeoPublisher(IPublishEndpoint publisher) : INeoPublisher
{
    public async Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        await publisher.Publish(message, cancellationToken);
    }
}
