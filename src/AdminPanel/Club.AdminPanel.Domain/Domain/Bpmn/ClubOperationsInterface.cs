using Neo.Bpms.Domain.Models.Service.Internal;

namespace Club.AdminPanel.Domain.Domain.Bpmn;

public class ClubOperationsInterface : InternalServiceGroupDefinition
{
    public ClubOperationsInterface() : base(nameof(ClubOperationsInterface))
    {
    }


    public override void AddOperations()
    {
        //AddOperation(new CalcBillingOperation());
    }
}
