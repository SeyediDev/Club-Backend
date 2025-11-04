using Club.Domain.Entities.Rewards;

namespace Club.AdminPanel.Domain.UiDefinitions.Awards;

public class AwardMerchantDefinitions : CRUDDefinition<RewardMerchant>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(RewardMerchant.Title),
                        nameof(RewardMerchant.CreateDate)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddField(nameof(RewardMerchant.Title));
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(Reward), nameof(Reward.Merchant), null/*"Sub"*/,
            "پاداش‌ها", null, false, eControlTypeId.MultiTab);
    }
}
