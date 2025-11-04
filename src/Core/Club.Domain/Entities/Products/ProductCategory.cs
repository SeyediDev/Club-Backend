using Club.Domain.Entities.Products.Enums;

namespace Club.Domain.Entities.Products;

/// <summary>
/// محصول یا خدمت سازمان - موجودیت برای مدیریت محصولات ارائه شده توسط سازمان
/// این موجودیت برای ثبت خرید یا استفاده مشتریان از محصولات سازمان و کسب امتیاز استفاده می‌شود
/// </summary>
[DisplayName("محصول سازمان")]
[SBVR(SBVRModality.Obligatory, "مدیریت محصولات سازمان", "هر محصول یا خدمت سازمان باید برای ثبت خرید، تخصیص امتیاز و تحلیل فروش قابل شناسایی باشد")]
[SBVR(SBVRModality.Recommended, "مدیریت محصولات سازمان", "محصولات سازمان باید برای تحلیل رفتار مشتریان، محاسبه ROI و بهینه‌سازی استراتژی‌های بازاریابی سازماندهی شوند")]
[OldDbMap("ProductOrServices")]
public class ProductCategory : ClubBaseCoreAuditableEntity<int>
{
    /// <summary>
    /// شناسه سازمان بهره‌بردار
    /// </summary>
    [DisplayName("شناسه سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر محصول باید به یک سازمان مشخص تعلق داشته باشد تا از تداخل داده‌ها جلوگیری شود")]
    public int TenantId { get; set; }

    /// <summary>
    /// سازمان بهره‌بردار
    /// </summary>
    [DisplayName("سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر محصول باید به یک سازمان مشخص تعلق داشته باشد")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// عنوان محصول
    /// </summary>
    [DisplayName("عنوان محصول")]
    [InDisplayString]
    [MaxLength(81)]
    [SBVR(SBVRModality.Obligatory, "شناسایی محصول", "عنوان برای نمایش در کاتالوگ و مدیریت محصولات ضروری است")]
    [SBVR(SBVRModality.Recommended, "شناسایی محصول", "عنوان باید واضح و قابل فهم باشد تا مشتریان بتوانند محصول مورد نظر خود را شناسایی کنند")]
    public string Title { get; set; } = null!;

    [MaxLength(40)]
    [DisplayName("کلید")]
    public string Key { get; set; } = null!;

    /// <summary>
    /// توضیحات محصول
    /// </summary>
    [DisplayName("توضیحات")]
    [MaxLength(1000)]
    [SBVR(SBVRModality.Recommended, "مستندسازی محصول", "توضیحات برای ارائه اطلاعات کامل به مشتریان و کارکنان استفاده می‌شود")]
    public string? Description { get; set; }

    /// <summary>
    /// نوع محصول یا خدمت
    /// </summary>
    [DisplayName("نوع محصول")]
    [SBVR(SBVRModality.Obligatory, "تمایز محصولات", "نوع برای تمایز بین محصولات فیزیکی، خدمات و محصولات دیجیتالی ضروری است")]
    [SBVR(SBVRModality.Recommended, "تمایز محصولات", "نوع برای تحلیل فروش، مدیریت موجودی و بهینه‌سازی استراتژی‌ها استفاده می‌شود")]
    public ProductType ProductType { get; set; }

    /// <summary>
    /// قیمت محصول (ریال)
    /// </summary>
    [DisplayName("قیمت (ریال)")]
    [SBVR(SBVRModality.Calculated, "قیمت‌گذاری", "قیمت برای محاسبه درآمد، تحلیل سودآوری و ارزیابی ارزش محصول استفاده می‌شود")]
    public decimal? Price { get; set; }

    /// <summary>
    /// تعداد امتیاز قابل کسب از خرید/استفاده این محصول
    /// </summary>
    [DisplayName("امتیاز قابل کسب")]
    [SBVR(SBVRModality.Recommended, "سیستم امتیازدهی", "امتیاز قابل کسب برای تشویق خرید و استفاده از محصولات سازمان و افزایش وفاداری مشتریان استفاده می‌شود")]
    [SBVR(SBVRModality.Calculated, "سیستم امتیازدهی", "امتیاز بر اساس ارزش محصول، میزان سودآوری و استراتژی‌های بازاریابی محاسبه می‌شود")]
    public long? PointsEarnable { get; set; }

    /// <summary>
    /// آیا محصول فعال است
    /// </summary>
    [DisplayName("فعال")]
    [SBVR(SBVRModality.Permitted, "مدیریت چرخه حیات", "وضعیت فعال برای کنترل نمایش محصولات در کاتالوگ و جلوگیری از فروش محصولات غیرفعال استفاده می‌شود")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// تعداد خرید/استفاده
    /// </summary>
    [DisplayName("تعداد خرید/استفاده")]
    [SBVR(SBVRModality.Calculated, "تحلیل محبوبیت", "تعداد خرید برای تحلیل محبوبیت محصول، الگوهای خرید و بهینه‌سازی کاتالوگ استفاده می‌شود")]
    public int PurchaseCount { get; set; }

    /// <summary>
    /// مقدار درآمد ایجاد شده
    /// </summary>
    [DisplayName("کل درآمد (ریال)")]
    [SBVR(SBVRModality.Calculated, "تحلیل درآمد", "کل درآمد برای محاسبه سودآوری محصول و ارزیابی تأثیر بر رشد کسب‌وکار استفاده می‌شود")]
    public decimal TotalRevenue { get; set; }

    public int? PictureId { get; set; }
    /// <summary>
    /// تصویر محصول
    /// </summary>
    [DisplayName("تصویر")]
    [SBVR(SBVRModality.Permitted, "نمایش بصری", "تصویر برای بهبود تجربه کاربری و افزایش نرخ تبدیل استفاده می‌شود")]
    public Document? Picture { get; set; }

    // ===== CONSUMPTION & CUSTOMER LIFETIME METRICS =====
    
    /// <summary>
    /// مدت زمان مصرف پیش‌بینی شده - مدت زمان پیش‌بینی شده برای مصرف محصول توسط مشتری (به روز)
    /// </summary>
    [DisplayName("مدت زمان مصرف پیش‌بینی شده (روز)")]
    [SBVR(SBVRModality.Predicted, "مدیریت پیش‌بینی مصرف", "مدت زمان مصرف پیش‌بینی شده برای برنامه‌ریزی خرید مجدد، مدیریت موجودی و طراحی برنامه‌های وفاداری استفاده می‌شود")]
    [SBVR(SBVRModality.Calculated, "مدیریت پیش‌بینی مصرف", "مدت زمان مصرف پیش‌بینی شده بر اساس تحلیل داده‌های تاریخی، الگوهای مصرف و نوع محصول محاسبه می‌شود")]
    public int? ExpectedConsumptionDuration { get; set; }

    /// <summary>
    /// فرکانس استفاده معمولی - فرکانس استفاده معمولی محصول توسط مشتریان
    /// </summary>
    [DisplayName("فرکانس استفاده معمولی")]
    [SBVR(SBVRModality.Recommended, "مدیریت الگوهای مصرف", "فرکانس استفاده برای طراحی زمان‌بندی کمپین‌های بازاریابی و پیشنهاد محصول استفاده می‌شود")]
    public TypicalUsageFrequency TypicalUsageFrequency { get; set; } = TypicalUsageFrequency.Unknown;

    /// <summary>
    /// چرخه خرید متوسط - متوسط تعداد روز بین خریدهای متوالی (به روز)
    /// </summary>
    [DisplayName("چرخه خرید متوسط (روز)")]
    [SBVR(SBVRModality.Calculated, "تحلیل رفتار خرید", "چرخه خرید متوسط برای پیش‌بینی خرید مجدد، زمان‌بندی کمپین‌ها و بهینه‌سازی موجودی استفاده می‌شود")]
    [SBVR(SBVRModality.Predicted, "تحلیل رفتار خرید", "چرخه خرید متوسط با تحلیل تاریخی فاصله بین خریدهای مشتریان و استفاده از مدل‌های زمان‌بندی محاسبه می‌شود")]
    public int? AveragePurchaseCycle { get; set; }

    /// <summary>
    /// آستانه سفارش مجدد - آستانه برای پیشنهاد خرید مجدد محصول (درصد باقیمانده)
    /// </summary>
    [DisplayName("آستانه سفارش مجدد (%)")]
    [SBVR(SBVRModality.Recommended, "مدیریت خرید مجدد", "آستانه سفارش مجدد برای زمان‌بندی تبلیغات محصول و تشویق خرید مجدد استفاده می‌شود")]
    [SBVR(SBVRModality.Calculated, "مدیریت خرید مجدد", "آستانه سفارش مجدد بر اساس ExpectedConsumptionDuration و الگوهای تاریخی محاسبه می‌شود")]
    public decimal? ReorderThreshold { get; set; }

    /// <summary>
    /// ارزش طول عمر مشتری (CLV) برای این محصول - ارزش پیش‌بینی شده طول عمر مشتری برای این محصول (ریال)
    /// </summary>
    [DisplayName("ارزش طول عمر مشتری (CLV محصول)")]
    [SBVR(SBVRModality.Calculated, "تحلیل ارزش طول عمر مشتری", "CLV محصول برای ارزیابی سودآوری محصول، تصمیم‌گیری تخصیص بودجه بازاریابی و طراحی استراتژی نگهداری مشتری استفاده می‌شود")]
    [SBVR(SBVRModality.Predicted, "تحلیل ارزش طول عمر مشتری", "CLV محصول = متوسط درآمد هر مشتری × نرخ نگهداری × تعداد خریدهای پیش‌بینی شده × طول عمر متوسط")]
    public decimal? CustomerLifetimeValueProduct { get; set; }

    /// <summary>
    /// طول عمر معمولی مشتری برای این محصول - طول عمر معمولی یک مشتری برای این محصول (به روز)
    /// </summary>
    [DisplayName("طول عمر معمولی مشتری (روز)")]
    [SBVR(SBVRModality.Predicted, "تحلیل طول عمر مشتری", "طول عمر معمولی مشتری برای ارزیابی پتانسیل درآمد و طراحی برنامه‌های نگهداری مشتری استفاده می‌شود")]
    [SBVR(SBVRModality.Calculated, "تحلیل طول عمر مشتری", "طول عمر معمولی مشتری = میانگین زمان بین اولین و آخرین خرید × نرخ نگهداری × نرخ Churn")]
    public int? TypicalCustomerLifetime { get; set; }

    /// <summary>
    /// متوسط تعداد خرید در طول عمر مشتری - متوسط تعداد دفعات خرید این محصول توسط یک مشتری
    /// </summary>
    [DisplayName("متوسط تعداد خرید در طول عمر")]
    [SBVR(SBVRModality.Calculated, "تحلیل رفتار خرید", "متوسط تعداد خرید برای ارزیابی وفاداری مشتری و پتانسیل تکرار خرید استفاده می‌شود")]
    [SBVR(SBVRModality.Predicted, "تحلیل رفتار خرید", "متوسط تعداد خرید = AveragePurchaseCycle / TypicalCustomerLifetime")]
    public decimal? AveragePurchasesPerCustomerLifetime { get; set; }

    /// <summary>
    /// نرخ تکرار خرید - نرخ مشتریانی که محصول را دوباره خریداری می‌کنند (درصد)
    /// </summary>
    [DisplayName("نرخ تکرار خرید (%)")]
    [SBVR(SBVRModality.Calculated, "تحلیل وفاداری", "نرخ تکرار خرید برای ارزیابی رضایت مشتری و اثربخشی محصول استفاده می‌شود")]
    [SBVR(SBVRModality.Recommended, "تحلیل وفاداری", "نرخ تکرار خرید بالای 40% نشان‌دهنده محصول محبوب و با کیفیت است")]
    public decimal? RepeatPurchaseRate { get; set; }
}
