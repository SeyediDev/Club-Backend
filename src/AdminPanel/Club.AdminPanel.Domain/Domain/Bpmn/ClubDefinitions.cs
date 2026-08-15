using Neo.Bpms.Domain.Features.Definitions.Entities.Processes;

namespace Club.AdminPanel.Domain.Domain.Club;

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