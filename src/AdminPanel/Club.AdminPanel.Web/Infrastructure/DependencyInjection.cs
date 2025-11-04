using Neo.Bpms.Domain.Entities.Cmmn.Data.Provider;
using Neo.Bpms.Domain.Features.Cmmn.ObjectStorage;
using Neo.Bpms.Infrastructure.Features.MetaLoader.Loader;
using Club.AdminPanel.Domain.Domain;
using Club.AdminPanel.Domain.Domain.Bpmn;
using Club.AdminPanel.Domain.Infrastructure.Cmmn;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Club.AdminPanel.Domain.Infrastructure;

public static class DependencyInjection
{
    public static void AddClubBpmsInfrastructures(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddScoped<ICmmnDocument, CmmnDocument>();
        _ = services.AddSingleton<IProjectMetaLoader, ProjectMetaLoader<ClubProjectDefinition, ClubServiceDefinitions, ClubMenuDefinitions>>();
        _ = services.AddSingleton<IDataProviderContainer, DataProviderContainer>();
    }
}
