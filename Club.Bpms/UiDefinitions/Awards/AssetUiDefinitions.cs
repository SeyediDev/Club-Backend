using Club.Domain.Entities.Rewards;

namespace Club.Bpms.UiDefinitions.Awards;

public class AssetDefinitions : Sub2CRUDDefinition<RewardAsset>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(RewardAsset.Reward),
                        nameof(RewardAsset.Customer),
                        nameof(RewardAsset.Serial),
                        nameof(RewardAsset.Quantity),
                        nameof(RewardAsset.ConsumedQuantity),
                        nameof(RewardAsset.RemainingQuantity)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(RewardAsset.Reward),
                       nameof(RewardAsset.Customer),
                       nameof(RewardAsset.Serial),
                       nameof(RewardAsset.Quantity),
                       nameof(RewardAsset.ConsumedQuantity),
                       nameof(RewardAsset.RemainingQuantity),
                       nameof(RewardAsset.EventLog),
                       nameof(RewardAsset.ScoringRule),
                       nameof(RewardAsset.ScoringRuleAction)
                       );
    }
    
    public override string SubjectId => "SubCustomer";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(RewardAsset.Reward),
                        nameof(RewardAsset.Serial),
                        nameof(RewardAsset.Quantity),
                        nameof(RewardAsset.ConsumedQuantity),
                        nameof(RewardAsset.RemainingQuantity)
                        );
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(RewardAsset.Reward),
                       nameof(RewardAsset.Serial),
                       nameof(RewardAsset.Quantity),
                       nameof(RewardAsset.ConsumedQuantity),
                       nameof(RewardAsset.RemainingQuantity),
                       nameof(RewardAsset.EventLog),
                       nameof(RewardAsset.ScoringRule),
                       nameof(RewardAsset.ScoringRuleAction)
                       );
    }

    public override string SubjectId2 => "SubAward";
    public override void Sub2IndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(RewardAsset.Customer),
                        nameof(RewardAsset.Serial),
                        nameof(RewardAsset.Quantity),
                        nameof(RewardAsset.ConsumedQuantity),
                        nameof(RewardAsset.RemainingQuantity)
                        );
    }

    public override void Sub2ViewModel(FormDefinition form)
    {
        form.AddFields(nameof(RewardAsset.Customer),
                       nameof(RewardAsset.Serial),
                       nameof(RewardAsset.Quantity),
                       nameof(RewardAsset.ConsumedQuantity),
                       nameof(RewardAsset.RemainingQuantity),
                       nameof(RewardAsset.EventLog),
                       nameof(RewardAsset.ScoringRule),
                       nameof(RewardAsset.ScoringRuleAction)
                       );
    }
}
