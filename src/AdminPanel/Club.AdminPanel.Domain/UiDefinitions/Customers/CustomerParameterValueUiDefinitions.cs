namespace Club.AdminPanel.Domain.UiDefinitions.Customers;

public class CustomerParameterValueUiDefinitions : SubCRUDDefinition<CustomerParameterValue>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumn(nameof(CustomerParameterValue.Parameter));
        form.AddColumn(nameof(CustomerParameterValue.Value));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddField(nameof(CustomerParameterValue.Parameter));
        form.AddField(nameof(CustomerParameterValue.Value));
        form.AddField(nameof(CustomerParameterValue.EventLog));
    }
}
