namespace Club.Domain.Entities.Events;

[DisplayName("رویداد کانال دریافت رویداد")]
public class EventChannelValidEventType : ClubBaseCoreConfigAuditableEntity<int>
{
    public int EventChannelId { get; set; }
    [DisplayName("کانال دریافت رویداد")]
    public EventChannel EventChannel { get; set; } = null!;

    public int EventTypeId { get; set; }
    [DisplayName("رویداد")]
    public EventType EventType { get; set; } = null!;
}
