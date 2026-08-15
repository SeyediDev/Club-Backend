using Club.Domain.Entities.Channels;

namespace Club.AdminPanel.Domain.UiDefinitions.Events;

public class EventChannelValidEventTypeUiDefinitions : SubCRUDDefinition<EventChannelValidEvent>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel()
    {
        AddColumns(nameof(EventChannelValidEvent.EventType));
    }

    public override void SubViewModel()
    {
        AddFields(nameof(EventChannelValidEvent.EventType));
    }
}
