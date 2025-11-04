namespace Club.Domain.Entities.Customers;

/// <summary>
/// می خواهیم برای هر مشتری سطح‌امتیازاش را در سازمان بهره‌بردار ذخیره کنیم
/// </summary>
[DisplayName("سطح‌امتیاز مشتری")]
public class CustomerPointLevel : ClubBaseCoreConfigAuditableEntity<int>
{
    public int CustomerId { get; set; }
    [DisplayName("مشتری")]
    public Customer Customer { get; set; } = null!;

    public int PointLevelId { get; set; }
    [DisplayName("سطح‌امتیاز")]
    public PointLevel PointLevel { get; set; } = null!;

    public long EventLogId { get; set; }
    [DisplayName("لاگ رویداد")]
    public EventLog EventLog { get; set; } = null!;
}
