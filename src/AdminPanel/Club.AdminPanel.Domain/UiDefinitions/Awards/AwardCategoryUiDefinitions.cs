using Club.Domain.Entities.Rewards;

namespace Club.AdminPanel.Domain.UiDefinitions.Awards;

public class ProductCategoryDefinitions : CRUDDefinition<RewardCategory>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(RewardCategory.Title),
                        nameof(RewardCategory.Category),
                        nameof(RewardCategory.CreateDate)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(RewardCategory.Title), 
                       nameof(RewardCategory.Category));
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(Reward), nameof(Reward.Merchant), null/*"Sub"*/,
            "پاداش‌ها", null, false, eControlTypeId.MultiTab);
    }
}