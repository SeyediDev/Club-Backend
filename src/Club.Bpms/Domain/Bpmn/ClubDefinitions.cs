using Neo.Bpms.Domain.Modeling.Definitions.Entities.Processes;

namespace Club.Bpms.Domain.Club;

public partial class ClubDefinitions : BpmnDefinitionsDefinition
{
    protected override bool Identify()
    {
        return Identify(nameof(Domains.Club));
    }

    protected override void DefineProcess()
    {
    }
}