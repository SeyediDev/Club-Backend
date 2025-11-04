using Club.Domain.Entities.Customers.Enums;

namespace Club.Domain.Entities.Customers;

[DisplayName("جامعه مشتریان")]
[SBVR(SBVRModality.Obligatory, "بخش‌بندی مشتریان", "هر جامعه مشتریان باید برای هدف‌گذاری کمپین‌ها، شخصی‌سازی خدمات و تحلیل رفتار قابل شناسایی باشد")]
[SBVR(SBVRModality.Recommended, "بخش‌بندی مشتریان", "جامعه‌ها باید برای بهینه‌سازی استراتژی‌های بازاریابی و افزایش نرخ تبدیل طراحی شوند")]
public partial class CustomerSegment : ClubBaseCoreAuditableEntity<int>
{
    public int TenantId { get; set; }
    [DisplayName("سازمان بهره‌بردار")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// عنوان جامعه مشتریان
    /// </summary>
    [DisplayName("عنوان جامعه مشتریان")]
    [InDisplayString]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "شناسایی جامعه", "عنوان جامعه باید برای مدیریت کمپین‌ها و گزارش‌گیری واضح و قابل فهم باشد")]
    public string Title { get; set; } = null!;

    /// <summary>
    /// توضیحات جامعه مشتریان
    /// </summary>
    [DisplayName("توضیحات جامعه مشتریان")]
    [MaxLength(512)]
    [SBVR(SBVRModality.Recommended, "مستندسازی جامعه", "توضیحات جامعه باید شامل معیارهای تشکیل و هدف از ایجاد جامعه باشد")]
    public string? Description { get; set; } = null!;

    /// <summary>
    /// وضعیت فعال جامعه
    /// </summary>
    [DisplayName("وضعیت فعال بودن جامعه")]
    [SBVR(SBVRModality.Recommended, "مدیریت چرخه حیات", "وضعیت فعال تعیین می‌کند که آیا جامعه در کمپین‌ها و تحلیل‌ها استفاده شود")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// تخمین تعداد جامعه
    /// </summary>
    [DisplayName("اندازه تخمینی جامعه")]
    [SBVR(SBVRModality.Calculated, "برنامه‌ریزی کمپین", "اندازه تخمینی برای برنامه‌ریزی بودجه و منابع کمپین‌ها استفاده می‌شود")]
    public int EstimatedSize { get; set; }

    /// <summary>
    /// تعداد واقعی جامعه
    /// </summary>
    [DisplayName("اندازه واقعی جامعه")]
    [SBVR(SBVRModality.Calculated, "تحلیل اثربخشی", "اندازه واقعی برای تحلیل اثربخشی کمپین‌ها و محاسبه نرخ تبدیل استفاده می‌شود")]
    public int ActualSize { get; set; }

    /// <summary>
    /// آخرین محاسبه جامعه
    /// </summary>
    [DisplayName("تاریخ آخرین محاسبه جامعه")]
    [SBVR(SBVRModality.Calculated, "مدیریت به‌روزرسانی", "تاریخ آخرین محاسبه برای اطمینان از به‌روز بودن داده‌های جامعه استفاده می‌شود")]
    public DateTime? LastCalculationDate { get; set; }

    /// <summary>
    /// فاصله محاسبه جامعه
    /// </summary>
    [DisplayName("فاصله زمانی محاسبه مجدد جامعه")]
    [SBVR(SBVRModality.Recommended, "اتوماسیون محاسبات", "فاصله زمانی تعیین می‌کند که جامعه هر چند روز یکبار محاسبه مجدد شود")]
    public int CalculationIntervalDays { get; set; } = 1;

    /// <summary>
    /// نحوه محاسبه جامعه
    /// </summary>
    [DisplayName("نحوه محاسبه جامعه")]
    [SBVR(SBVRModality.Recommended, "روش‌شناسی محاسبه", "نحوه محاسبه تعیین می‌کند که جامعه بر اساس چه الگوریتمی تشکیل شود")]
    public SegmentCalculationMode CalculationMode { get; set; } = SegmentCalculationMode.Automatic;

    /// <summary>
    /// حداقل امتیاز عضویت
    /// </summary>
    [DisplayName("حداقل نمره عضویت در جامعه")]
    [SBVR(SBVRModality.Calculated, "تعریف مرزهای جامعه", "حداقل نمره عضویت برای تعیین مرزهای جامعه و جلوگیری از تداخل استفاده می‌شود")]
    public decimal? MinMembershipScore { get; set; }

    /// <summary>
    /// حداکثر امتیاز عضویت
    /// </summary>
    [DisplayName("حداکثر نمره عضویت در جامعه")]
    [SBVR(SBVRModality.Calculated, "تعریف مرزهای جامعه", "حداکثر نمره عضویت برای تعیین مرزهای جامعه و جلوگیری از تداخل استفاده می‌شود")]
    public decimal? MaxMembershipScore { get; set; }

    /// <summary>
    /// نرخ رشد جامعه
    /// </summary>
    [DisplayName("نرخ رشد جامعه")]
    [SBVR(SBVRModality.Calculated, "تحلیل روندها", "نرخ رشد جامعه برای تحلیل روندهای بازار و پیش‌بینی نیازهای آینده استفاده می‌شود")]
    public decimal GrowthRate { get; set; }

    /// <summary>
    /// نرخ نگهداری جامعه
    /// </summary>
    [DisplayName("نرخ حفظ مشتریان جامعه")]
    [SBVR(SBVRModality.Calculated, "تحلیل وفاداری", "نرخ حفظ برای تحلیل وفاداری مشتریان و بهینه‌سازی استراتژی‌های حفظ مشتری استفاده می‌شود")]
    public decimal RetentionRate { get; set; }

    /// <summary>
    /// نرخ تعامل جامعه
    /// </summary>
    [DisplayName("نرخ تعامل جامعه")]
    [SBVR(SBVRModality.Calculated, "تحلیل مشارکت", "نرخ تعامل برای تحلیل میزان مشارکت مشتریان در جامعه و بهینه‌سازی محتوا استفاده می‌شود")]
    public decimal EngagementRate { get; set; }

    /// <summary>
    /// نحوه عضویت در جامعه
    /// </summary>
    [DisplayName("نحوه عضویت در جامعه")]
    [SBVR(SBVRModality.Obligatory, "مدیریت عضویت", "نحوه عضویت تعیین می‌کند که مشتری چگونه می‌تواند عضو جامعه شود")]
    [SBVR(SBVRModality.Recommended, "کنترل دسترسی", "انتخاب صحیح نحوه عضویت برای جلوگیری از عضویت نامناسب ضروری است")]
    public CustomerSegmentJoinMode JoinMode { get; set; } = CustomerSegmentJoinMode.SystemOnly;

    /// <summary>
    /// قابلیت نمایش در پرتال مشتریان
    /// </summary>
    [DisplayName("نمایش در پرتال مشتریان")]
    [SBVR(SBVRModality.Recommended, "نمایش جامعه", "تعیین می‌کند که آیا جامعه در پرتال مشتریان قابل مشاهده است")]
    [SBVR(SBVRModality.Permitted, "محرمانگی", "برخی جامعه‌ها ممکن است محرمانه باشند و نباید در پرتال نمایش داده شوند")]
    public bool IsVisibleInPortal { get; set; } = false;

    /// <summary>
    /// آدرس تصویر جامعه
    /// </summary>
    [DisplayName("آدرس تصویر جامعه")]
    [MaxLength(512)]
    [SBVR(SBVRModality.Permitted, "تجربه کاربری", "تصویر جامعه برای بهبود تجربه کاربری در پرتال مشتریان استفاده می‌شود")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// مزایای عضویت در جامعه (JSON array)
    /// </summary>
    [DisplayName("مزایای عضویت")]
    [MaxLength(2000)]
    [SBVR(SBVRModality.Recommended, "انگیزش مشتری", "مزایای عضویت برای ترغیب مشتریان به عضویت در جامعه استفاده می‌شود")]
    public string? Benefits { get; set; }

    // Navigation Properties
    public ICollection<CustomerSegmentKindCondition> KindConditions { get; set; } = [];
    public ICollection<CustomerSegmentMembership> Memberships { get; set; } = [];
}

/// <summary>
/// نحوه محاسبه جامعه - تعیین روش محاسبه جامعه
/// </summary>
public enum SegmentCalculationMode
{
    /// <summary>
    /// خودکار - بر اساس شرط‌های تعریف شده
    /// </summary>
    Automatic = 1,

    /// <summary>
    /// دستی - توسط کاربر تعریف می‌شود
    /// </summary>
    Manual = 2,

    /// <summary>
    /// ترکیبی - ترکیب خودکار و دستی
    /// </summary>
    Hybrid = 3,

    /// <summary>
    /// هوشمند - بر اساس الگوریتم‌های پیشرفته
    /// </summary>
    Intelligent = 4
}