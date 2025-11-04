namespace Club.AdminPanel.Domain.UiDefinitions.Customers;

/// <summary>
/// تعاریف UI برای موجودیت کد معرف
/// </summary>

public class ReferrerCodeUiDefinitions : SubCRUDDefinition<ReferrerCode>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(ReferrerCode.Tenant),
        nameof(ReferrerCode.Customer),
        nameof(ReferrerCode.Code));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(ReferrerCode.Tenant),
        nameof(ReferrerCode.Customer),
        nameof(ReferrerCode.Code));
    }
}