namespace Club.Domain.Entities.Events;

[DisplayName("ویژگی های مجاز رویداد")]
public class EventTypeValidAttribute : ClubBaseCoreConfigAuditableEntity<int>, ISubOfEventType
{
    public int EventTypeId { get; set; }
    [DisplayName("رویداد")]
    public EventType EventType { get; set; } = null!;

    public int AttributeId { get; set; }
    [DisplayName("ویژگی")]
    public TenantAttribute Attribute { get; set; } = null!;
}