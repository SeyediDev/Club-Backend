namespace Club.AdminPanel.Domain.UiDefinitions.Promotions;

public partial class PromotionUiDefinitions : CRUDDefinition<Promotion>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Promotion.Title),
                        nameof(Promotion.Category),
                        nameof(Promotion.CustomerSegment),
                        nameof(Promotion.FromDate),
                        nameof(Promotion.ToDate),
                        nameof(Promotion.CounterWindowMode),
                        nameof(Promotion.Threshold),
                        nameof(Promotion.TriggerKind),
                        nameof(Promotion.CheckTime),
                        nameof(Promotion.Tenant)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Promotion.Title),
                       nameof(Promotion.Category),
                       nameof(Promotion.CustomerSegment),
                       nameof(Promotion.FromDate),
                       nameof(Promotion.ToDate),
                       nameof(Promotion.CounterWindowMode),
                       nameof(Promotion.Threshold),
                       nameof(Promotion.TriggerKind),
                       nameof(Promotion.CheckTime),
                       nameof(Promotion.WeekDay),
                       nameof(Promotion.MonthDay)
                       );
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        //form.AddSubTable(nameof(Product), nameof(Product.Merchant), null/*"Sub"*/,
        //    "محصولات", null, false, eControlTypeId.MultiTab);
    }
}