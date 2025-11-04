using Club.Domain.Entities.Rewards;

namespace Club.Bpms.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions : CRUDDefinition<Customer>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Customer.FirstName),
                        nameof(Customer.LastName),
                        nameof(Customer.NationalCode),
                        nameof(Customer.MobileNo),
                        nameof(Customer.BirthDate)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Customer.FirstName),
                       nameof(Customer.LastName),
                       nameof(Customer.NationalCode),
                       nameof(Customer.MobileNo),
                       nameof(Customer.BirthDate)
                       );
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        var groupControl = eControlTypeId.None;
        var editable = true;
        form.AddSubTable(nameof(CustomerParameterValue), nameof(CustomerParameterValue.Customer), "Sub",
            "مقادیر", null, editable, groupControl);
        form.AddSubTable(nameof(CustomerPointLevel), nameof(CustomerPointLevel.Customer), "Sub",
            "سطوح امتیازی", null, editable, groupControl);
        form.AddSubTable(nameof(CustomerSegmentMembership), nameof(CustomerSegmentMembership.Customer), "Sub",
            "عضویت جامعه مشتریان", null, editable, groupControl);
        form.AddSubTable(nameof(CustomerTransaction), nameof(CustomerTransaction.Customer), "Sub",
            "امتیازات", null, editable, groupControl);
        form.AddSubTable(nameof(RewardAsset), nameof(RewardAsset.Customer), "SubCustomer",
            "دارایی ها", null, editable, groupControl);
        form.AddSubTable(nameof(CustomerReferrer), nameof(CustomerReferrer.ReferredCustomer), null,
            "معرف ها", null, editable, groupControl);
        form.AddSubTable(nameof(CustomerReferrer), nameof(CustomerReferrer.ReferrerCustomer), null,
            "معرفی ها", null, editable, groupControl);
    }
    // =====================================================
    // Customer Reports
    // =====================================================

    /// <summary>
    /// گزارش عمومی مشتریان
    /// </summary>
    public new partial class PublicReport: CRUDDefinition.PublicReport
    {
    }
}
