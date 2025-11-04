namespace Club.AdminPanel.Domain.UiDefinitions.Promotions;

public class LotteryRewardDefinitions : CRUDDefinition<LotteryReward>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(LotteryReward.Lottery),
                        nameof(LotteryReward.Award),
                        nameof(LotteryReward.Amount),
                        nameof(LotteryReward.WinRate),
                        nameof(LotteryReward.MaxDistributionCount),
                        nameof(LotteryReward.DistributedCount),
                        nameof(LotteryReward.DisplayOrder),
                        nameof(LotteryReward.IsActive)
                        );
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(LotteryReward.Lottery),
                       nameof(LotteryReward.Award),
                       nameof(LotteryReward.Amount),
                       nameof(LotteryReward.WinRate),
                       nameof(LotteryReward.MaxDistributionCount),
                       nameof(LotteryReward.DisplayOrder),
                       nameof(LotteryReward.IsActive)
                       );
    }
    
    protected override void EditFormSubTables(CUDForm form)
    {
        // Sub-tables can be added here if needed
    }
}

