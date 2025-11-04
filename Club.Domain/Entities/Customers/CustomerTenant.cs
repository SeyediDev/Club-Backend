namespace Club.Domain.Entities.Customers;

/// <summary>
/// رابطه مشتری با سازمان‌های بهره‌بردار
/// یک مشتری می‌تواند به چندین سازمان تعلق داشته باشد
/// </summary>
[DisplayName("مشتری سازمان")]
[SBVR(SBVRModality.Obligatory, "چند سازمانی", "هر رابطه مشتری-سازمان باید برای جداسازی داده‌ها و مدیریت دسترسی قابل شناسایی باشد")]
public class CustomerTenant : ClubBaseCoreAuditableEntity<int>
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    [DisplayName("مشتری")]
    public int CustomerId { get; set; }

    [DisplayName("مشتری")]
    public Customer Customer { get; set; } = null!;

    /// <summary>
    /// شناسه سازمان بهره‌بردار
    /// </summary>
    [DisplayName("سازمان بهره‌بردار")]
    public int TenantId { get; set; }

    [DisplayName("سازمان بهره‌بردار")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// تاریخ عضویت در سازمان
    /// </summary>
    [DisplayName("تاریخ عضویت")]
    [SBVR(SBVRModality.Recommended, "ردیابی عضویت", "تاریخ عضویت برای تحلیل دوره عضویت و مانده مشتری مهم است")]
    public DateTime JoinDate { get; set; } = DateTime.Now;

    /// <summary>
    /// تاریخ ترک سازمان (در صورت خروج مشتری)
    /// </summary>
    [DisplayName("تاریخ ترک")]
    [SBVR(SBVRModality.Permitted, "مدیریت خروج", "تاریخ ترک برای تحلیل نرخ Churn و بازگشت مشتری استفاده می‌شود")]
    public DateTime? LeaveDate { get; set; }

    /// <summary>
    /// وضعیت عضویت فعال
    /// </summary>
    [DisplayName("وضعیت فعال")]
    [SBVR(SBVRModality.Obligatory, "مدیریت عضویت", "وضعیت فعال تعیین می‌کند که آیا مشتری در سازمان فعال است")]
    public bool IsActive { get; set; } = true;
}

