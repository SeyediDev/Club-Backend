namespace Club.Domain.Entities.Customers;

[DisplayName("عضویت جامعه مشتریان")]
public class CustomerSegmentMembership : ClubBaseCoreAuditableEntity<int>
{
    public int CustomerId { get; set; }
    [DisplayName("مشتری")]
    public Customer Customer { get; set; } = null!;

    public int SegmentId { get; set; }
    [DisplayName("جامعه")]
    public CustomerSegment Segment { get; set; } = null!;

    public long EventLogId { get; set; }
    [DisplayName("لاگ رویداد")]
    public EventLog EventLog { get; set; } = null!;
}
