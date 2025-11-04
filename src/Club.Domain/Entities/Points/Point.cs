using Club.Domain.Entities.Points.Enums;

namespace Club.Domain.Entities.Points;

[DisplayName("امتیاز")]
[SBVR(SBVRModality.Obligatory, "سیستم امتیازدهی", "هر امتیاز باید برای تشویق رفتارهای مطلوب مشتریان و محاسبه تراکنش‌ها قابل شناسایی باشد")]
[SBVR(SBVRModality.Recommended, "سیستم امتیازدهی", "امتیازات باید برای افزایش وفاداری مشتریان و تحلیل اثربخشی کمپین‌ها طراحی شوند")]
public class Point : ClubBaseCoreConfigAuditableEntity<int>
{
    /// <summary>
    /// شناسه سازمان بهره‌بردار
    /// </summary>
    [DisplayName("شناسه سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر امتیاز باید به یک سازمان مشخص تعلق داشته باشد تا از تداخل قوانین امتیازدهی جلوگیری شود")]
    public int TenantId { get; set; }

    /// <summary>
    /// سازمان بهره‌بردار
    /// </summary>
    [DisplayName("سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر امتیاز باید به یک سازمان مشخص تعلق داشته باشد تا از تداخل قوانین امتیازدهی جلوگیری شود")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// نوع امتیاز
    /// </summary>
    [DisplayName("نوع امتیاز")]
    [SBVR(SBVRModality.Obligatory, "دسته‌بندی امتیازات", "نوع امتیاز تعیین می‌کند که امتیاز برای چه نوع فعالیتی اعطا می‌شود")]
    public PointType PointType { get; set; }

    /// <summary>
    /// عنوان امتیاز
    /// </summary>
    [DisplayName("عنوان امتیاز")]
    [InDisplayString]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "شناسایی امتیاز", "عنوان امتیاز باید برای نمایش در تراکنش‌ها و گزارش‌ها واضح و قابل فهم باشد")]
    public string Title { get; set; } = null!;

    /// <summary>
    /// بازدید خودکار
    /// </summary>
    [DisplayName("بازدید خودکار")]
    [SBVR(SBVRModality.Permitted, "افزایش سر زدن به صفحه باشگاه", "بعضی از امتیازها لازم است کاربر حتما به صفحه باشگاه مشتریان سر بزند و بگوید که این امتیاز را دیده تا به صورت واقعی آن را کسب کند.")]
    public bool? AutoVisit { get; set; }

    /// <summary>
    /// قابل مشاهده
    /// </summary>
    [DisplayName("قابل مشاهده")]
    [SBVR(SBVRModality.Recommended, "شفافیت امتیازدهی", "قابل مشاهده تعیین می‌کند که آیا امتیاز برای مشتریان قابل مشاهده باشد تا اعتماد افزایش یابد")]
    public bool? Visible { get; set; }

    /// <summary>
    /// قابل انتقال
    /// </summary>
    [DisplayName("قابل انتقال")]
    [SBVR(SBVRModality.Recommended, "امکانات امتیازدهی", "قابل انتقال تعیین می‌کند که آیا امتیاز مشتریان قابل انتقال به دیگر مشتریان هست ؟")]
    public bool? Transferable { get; set; }
}
