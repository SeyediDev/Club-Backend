using Club.Domain.Entities.Channels;

namespace Club.AdminPanel.Domain.UiDefinitions.Events;

public class EventChannelValidIpUiDefinitions : SubCRUDDefinition<EventChannelValidIp>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel()
    {
        AddColumns(nameof(EventChannelValidIp.ValidIp));
    }

    public override void SubViewModel()
    {
        AddFields(nameof(EventChannelValidIp.ValidIp));
    }
}
