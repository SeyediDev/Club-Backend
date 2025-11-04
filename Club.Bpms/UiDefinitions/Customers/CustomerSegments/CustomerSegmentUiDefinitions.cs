namespace Club.Bpms.UiDefinitions.Customers.CustomerSegments;

public partial class CustomerSegmentUiDefinitions : SubCRUDDefinition<CustomerSegment>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(CustomerSegment.Title),
                        nameof(CustomerSegment.IsActive),
                        nameof(CustomerSegment.EstimatedSize),
                        nameof(CustomerSegment.Tenant));
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(CustomerSegment.Tenant),
                       nameof(CustomerSegment.Title),
                       nameof(CustomerSegment.IsActive),
                       nameof(CustomerSegment.EstimatedSize),
                       nameof(CustomerSegment.Description));
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(CustomerSegmentKindCondition), nameof(CustomerSegmentKindCondition.CustomerSegment), null,
            "شرط‌های جامعه‌سازی", null, false);
    }
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(CustomerSegment.Title),
                        nameof(CustomerSegment.IsActive),
                        nameof(CustomerSegment.EstimatedSize));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(CustomerSegment.Title),
                       nameof(CustomerSegment.IsActive),
                       nameof(CustomerSegment.EstimatedSize),
                       nameof(CustomerSegment.Description));
    }
}
