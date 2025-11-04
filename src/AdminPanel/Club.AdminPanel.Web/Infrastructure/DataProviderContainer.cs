using Neo.Bpms.Domain.Entities.Cmmn.Data.Provider;
using Neo.Bpms.Infrastructure.Features.Orm.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Club.AdminPanel.Domain.Infrastructure;

public class DataProviderContainer(IConfiguration configuration, ILogger<DataProviderContainer> logger) : IDataProviderContainer
{
    private Dictionary<string, IDataProvider> _providers;
    private const string DefaultProviderName = "default";

    public IEnumerator<IDataProvider> GetEnumerator()
    {
        return _providers.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Init()
    {
        _providers = new Dictionary<string, IDataProvider>
        {
            { DefaultProviderName, new SqlServerProvider(configuration, logger, DefaultProviderName) },
            { nameof(DomainProvider.Domain), new SqlServerProvider(configuration, logger, nameof(DomainProvider.Domain), false) },
        };
    }

    public IDataProvider GetProvider(string providerName)
    {
        _providers.TryGetValue(providerName, out IDataProvider provider);
        if (provider == null)
            _providers.TryGetValue(nameof(DomainProvider.Domain), out provider);
        return provider;
    }
}
