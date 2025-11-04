using Neo.Bpms.Domain.Entities.Cmmn.Common;
using Neo.Domain.Entities.Common;

namespace Club.Bpms.Domain.Club;

public class ClubNamespace : ModelDefinition<ClubNamespace>
{
    protected override bool Identify()
    {
        return DefineModel(nameof(Domains.Club), "پلتفرم باشگاه مشتریان", null, nameof(DomainProvider.Domain));
    }
    protected override void Partitions()
    {
        AddPartitionFunction("pfArchive", typeof(bool),
            Neo.Bpms.Domain.Entities.Cmmn.Partitions.PartitionFunctionType.FixRange,
            Neo.Bpms.Domain.Entities.Cmmn.Partitions.PartitionFunctionBoundaryType.Left,
            "0", "1", "0", "1");
        AddArchivePartitionScheme(nameof(DomainSchema.CoreCommon));
        AddArchivePartitionScheme(nameof(DomainSchema.CoreConfig));
        AddArchivePartitionScheme(nameof(DomainSchema.Core));
        AddArchivePartitionScheme(nameof(DomainSchema.CoreLog));
    }

    protected override void Entities()
    {
        DefineEntity<HomePageEntity>();
        DefineEntities<IDomainEventEntity>(typeof(Language).Assembly);
        DefineEntities<IDomainEventEntity>(typeof(Point).Assembly);
    }

    private void AddArchivePartitionScheme(string name)
    {
        AddPartitionScheme($"Archive_{name}", "pfArchive",
            Neo.Bpms.Domain.Entities.Cmmn.Partitions.FileGroupSelectionType.FromList,
            "", name, $"{name}_Archive");
    }
}