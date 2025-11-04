namespace Club.Bpms.UiDefinitions.Events;

public class EventChannelValidEventTypeUiDefinitions : SubCRUDDefinition<EventChannelValidEventType>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(EventChannelValidEventType.EventType));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(EventChannelValidEventType.EventType));
    }
}
