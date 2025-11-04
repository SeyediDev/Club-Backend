using Club.Domain.Entities.Customers.Enums;

namespace Club.Domain.Entities.Customers;

/// <summary>
/// می خواهیم تراکنش امتیازات های هر مشتری را ذخیره کنیم
/// به ازای هر تغییر یک رکورد جدید اضافه می شود
/// به ازای بازدید کاربر از امتیازاتش فیلد VisitedAt پر میشود
/// </summary>
[Entity_Index($"{nameof(CustomerId)},{nameof(VisitedAt)},{nameof(IsDeleted)}")]
[DisplayName("تراکنش مشتری")]
public class CustomerTransaction : ClubBaseCoreAuditableEntity<long>
{
    public int TenantId { get; set; }
    [DisplayName("سازمان بهره‌بردار")]
    public Tenant Tenant { get; set; } = null!;

    public int CustomerId { get; set; }
    [DisplayName("مشتری")]
    public Customer Customer { get; set; } = null!;

    public int PointId { get; set; }
    [DisplayName("امتیاز")]
    public Point Point { get; set; } = null!;

    [DisplayName("بدهکار")]
    [SBVR(SBVRModality.Obligatory, "ثبت کاهش امتیاز", "بدهکار برای ثبت تمام کاهش‌های امتیاز مشتری ضروری است")]
    [SBVR(SBVRModality.Recommended, "ثبت کاهش امتیاز", "بدهکار برای ردیابی استفاده از امتیازات و تحلیل رفتار مشتری استفاده می‌شود")]
    public long? Debit { get; set; }

    [DisplayName("بستانکار")]
    [SBVR(SBVRModality.Obligatory, "ثبت افزایش امتیاز", "بستانکار برای ثبت تمام افزایش‌های امتیاز مشتری ضروری است")]
    [SBVR(SBVRModality.Recommended, "ثبت افزایش امتیاز", "بستانکار برای ردیابی کسب امتیازات و محاسبه Loyalty Score استفاده می‌شود")]
    public long? Credit { get; set; }

    [DisplayName("مانده")]
    [SBVR(SBVRModality.Obligatory, "مانده حساب", "مانده برای نمایش امتیازات قابل استفاده مشتری ضروری است")]
    [SBVR(SBVRModality.Calculated, "مانده حساب", "مانده = مانده قبلی + بستانکار - بدهکار")]
    public long Balance { get; set; }

    [DisplayName("نوع عملیات")]
    [SBVR(SBVRModality.Obligatory, "دسته‌بندی تراکنش", "نوع عملیات برای تفکیک منابع تراکنش و تحلیل رفتار ضروری است")]
    [SBVR(SBVRModality.Recommended, "دسته‌بندی تراکنش", "نوع عملیات برای گروه‌بندی تراکنش‌ها و تحلیل الگوهای استفاده از امتیاز استفاده می‌شود")]
    public CustomerTransactionType TransactionType { get; set; }

    [DisplayName("تاریخ بازدید")]
    [SBVR(SBVRModality.Calculated, "ردیابی تعامل", "تاریخ بازدید پس از مشاهده امتیاز توسط مشتری ثبت می‌شود")]
    public DateTime? VisitedAt { get; set; }

    public long EventLogId { get; set; }
    [DisplayName("لاگ رویداد")]
    public EventLog EventLog { get; set; } = null!;

    public int? ScoringRuleId { get; set; }
    [DisplayName("قانون‌امتیازدهی")]
    public ScoringRule? ScoringRule { get; set; }

    public int? ScoringRuleActionId { get; set; }
    [DisplayName("عملیات قانون‌امتیازدهی")]
    public ScoringRuleAction? ScoringRuleAction { get; set; }
}
