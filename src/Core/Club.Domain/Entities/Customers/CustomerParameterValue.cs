namespace Club.Domain.Entities.Customers;

/// <summary>
/// می خواهیم مقدار پارامتر به ازای هر مشتری ذخیره کنیم
/// </summary>
[DisplayName("مقدار پارامتر مشتری")]
[Entity_Index($"{nameof(CustomerId)},{nameof(ParameterId)},{nameof(IsDeleted)}")]
public class CustomerParameterValue : ClubBaseCoreAuditableEntity<int>
{
    public int CustomerId { get; set; }
    [DisplayName("مشتری")]
    public Customer Customer { get; set; } = null!;

    public int ParameterId { get; set; }
    [DisplayName("پارامتر")]
    public CustomerParameter Parameter { get; set; } = null!;

    [DisplayName("مقدار")]
    [MaxLength(512)]
    public string Value { get; set; } = null!;

    public long EventLogId { get; set; }
    [DisplayName("لاگ رویداد")]
    public EventLog EventLog { get; set; } = null!;
}
