using Club.Domain.Entities.Rewards;

namespace Club.Bpms.UiDefinitions.Awards;

public class AwardCostUiDefinitions : SubCRUDDefinition<RewardCost>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(RewardCost.Point),
                        nameof(RewardCost.Amount),
                        nameof(RewardCost.PointLevel));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(RewardCost.Point),
                       nameof(RewardCost.Amount),
                       nameof(RewardCost.PointLevel));
    }
}
