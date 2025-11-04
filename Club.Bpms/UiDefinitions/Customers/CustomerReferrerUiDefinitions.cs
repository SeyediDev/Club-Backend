namespace Club.Bpms.UiDefinitions.Customers;

/// <summary>
/// تعاریف UI برای موجودیت معرفی مشتری
/// </summary>
public class CustomerReferrerUiDefinitions : SubCRUDDefinition<CustomerReferrer>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(CustomerReferrer.Tenant),
        nameof(CustomerReferrer.ReferrerCode),
        nameof(CustomerReferrer.ReferrerCustomer),
        nameof(CustomerReferrer.ReferredCustomer));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(CustomerReferrer.Tenant),
        nameof(CustomerReferrer.ReferrerCode),
        nameof(CustomerReferrer.ReferrerCustomer),
        nameof(CustomerReferrer.ReferredCustomer),
        nameof(CustomerReferrer.EventLog),
        nameof(CustomerReferrer.Rule),
        nameof(CustomerReferrer.RuleAction)
        );
    }
}