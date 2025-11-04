namespace Club.Domain.Entities.Customers;

/// <summary>
/// ثبت معرفی‌های موفق مشتریان
/// این موجودیت برای ردیابی دعوت‌های موفق و مدیریت پاداش‌ها استفاده می‌شود
/// </summary>
[DisplayName("معرفی مشتری")]
[Entity_Index($"{nameof(ReferrerCodeId)},{nameof(ReferredCustomerId)},{nameof(IsDeleted)}")]
public class CustomerReferrer : ClubBaseCoreAuditableEntity<int>
{
    public int TenantId { get; set; }
    [DisplayName("سازمان بهره‌بردار")]
    public Tenant Tenant { get; set; } = null!;

    public int ReferrerCodeId { get; set; }
    [DisplayName("کد معرف")]
    public ReferrerCode ReferrerCode { get; set; } = null!;

    /// <summary>
    /// مشتری معرف
    /// </summary>
    public int ReferrerCustomerId { get; set; }
    [DisplayName("مشتری معرف")]
    public Customer ReferrerCustomer { get; set; } = null!;

    /// <summary>
    /// مشتری دعوت شده
    /// </summary>
    public int ReferredCustomerId { get; set; }
    [DisplayName("مشتری دعوت شده")]
    public Customer ReferredCustomer { get; set; } = null!;

    public long EventLogId { get; set; }
    [DisplayName("لاگ رویداد")]
    public EventLog EventLog { get; set; } = null!;

    public int? RuleId { get; set; }
    [DisplayName("قانون")]
    public ScoringRule? Rule { get; set; }

    public int? RuleActionId { get; set; }
    [DisplayName("عملیات قانون")]
    public ScoringRuleAction? RuleAction { get; set; }
}
