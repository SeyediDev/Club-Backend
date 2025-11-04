namespace Club.Bpms.UiDefinitions.Events;

public class EventChannelValidIpUiDefinitions : SubCRUDDefinition<EventChannelValidIp>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(EventChannelValidIp.ValidIp));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(EventChannelValidIp.ValidIp));
    }
}
