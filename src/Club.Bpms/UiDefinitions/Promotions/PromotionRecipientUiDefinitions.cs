namespace Club.Bpms.UiDefinitions.Promotions;

public class PromotionRecipientDefinitions : SubCRUDDefinition<PromotionRecipient>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(PromotionRecipient.Promotion),
                        nameof(PromotionRecipient.Customer),
                        nameof(PromotionRecipient.Status),
                        nameof(PromotionRecipient.SentDate),
                        nameof(PromotionRecipient.DeliveredDate),
                        nameof(PromotionRecipient.ReadDate),
                        nameof(PromotionRecipient.EngagementScore),
                        nameof(PromotionRecipient.ClickCount),
                        nameof(PromotionRecipient.ResponseCount)
                        );
    }

    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(PromotionRecipient.Promotion),
                       nameof(PromotionRecipient.Customer),
                       nameof(PromotionRecipient.Status),
                       nameof(PromotionRecipient.SentDate),
                       nameof(PromotionRecipient.DeliveredDate),
                       nameof(PromotionRecipient.ReadDate),
                       nameof(PromotionRecipient.ErrorMessage),
                       nameof(PromotionRecipient.EngagementScore),
                       nameof(PromotionRecipient.ClickCount),
                       nameof(PromotionRecipient.ResponseCount),
                       nameof(PromotionRecipient.ResponseTime),
                       nameof(PromotionRecipient.ResponseType),
                       nameof(PromotionRecipient.ResponseText)
                       );
    }

    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(PromotionRecipient.Customer),
                        nameof(PromotionRecipient.Status),
                        nameof(PromotionRecipient.SentDate),
                        nameof(PromotionRecipient.DeliveredDate),
                        nameof(PromotionRecipient.EngagementScore),
                        nameof(PromotionRecipient.ClickCount)
                        );
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(PromotionRecipient.Customer),
                       nameof(PromotionRecipient.Status),
                       nameof(PromotionRecipient.SentDate),
                       nameof(PromotionRecipient.DeliveredDate),
                       nameof(PromotionRecipient.ReadDate),
                       nameof(PromotionRecipient.ErrorMessage),
                       nameof(PromotionRecipient.EngagementScore),
                       nameof(PromotionRecipient.ClickCount),
                       nameof(PromotionRecipient.ResponseCount),
                       nameof(PromotionRecipient.ResponseTime),
                       nameof(PromotionRecipient.ResponseType),
                       nameof(PromotionRecipient.ResponseText)
                       );
    }
}
