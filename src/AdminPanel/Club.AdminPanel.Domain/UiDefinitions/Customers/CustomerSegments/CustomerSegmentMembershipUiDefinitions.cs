namespace Club.AdminPanel.Domain.UiDefinitions.Customers.CustomerSegments;

public class CustomerSegmentMembershipUiDefinitions : SubCRUDDefinition<CustomerSegmentMembership>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(CustomerSegmentMembership.Segment));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddField(nameof(CustomerSegmentMembership.Segment));
        form.AddField(nameof(CustomerSegmentMembership.CreateDate));
        form.AddField(nameof(CustomerSegmentMembership.EventLog));
    }
}
