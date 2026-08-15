using Neo.Domain.Entities.Integrations;
using Neo.Domain.Features.Integrations;

namespace Club.CallCenter.Api.Services;

internal sealed class NoopExternalApiService : IExternalApiService
{
    public Task<ExternalApiInvocationResult> InvokeAsync(ExternalApi externalApi, ExternalApiRequest request, CancellationToken cancellationToken = default)
    {
        ExternalApiInvocationResult result = new(200, "{}", new Dictionary<string, string[]>());
        return Task.FromResult(result);
    }
}

