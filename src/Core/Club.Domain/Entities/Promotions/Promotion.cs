namespace Club.Domain.Entities.Promotions;

[DisplayName("پویش")]
[SBVR(SBVRModality.Obligatory, "کمپین‌های بازاریابی", "هر پویش باید برای تشویق رفتارهای مطلوب مشتریان و افزایش فروش قابل اجرا باشد")]
[SBVR(SBVRModality.Recommended, "کمپین‌های بازاریابی", "پویش‌ها باید برای تحلیل اثربخشی، محاسبه ROI و بهینه‌سازی استراتژی‌های بازاریابی طراحی شوند")]
public class Promotion : ClubBaseCoreConfigAuditableEntity<int>
{
    public int TenantId { get; set; }

    [DisplayName("سازمان بهره‌بردار")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// عنوان پویش
    /// </summary>
    [DisplayName("عنوان پویش")]
    [InDisplayString]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "شناسایی کمپین", "عنوان پویش باید برای مدیریت کمپین‌ها و گزارش‌گیری واضح و قابل فهم باشد")]
    public string Title { get; set; } = null!;

    /// <summary>
    /// دسته‌بندی پویش
    /// </summary>
    [DisplayName("دسته‌بندی پویش")]
    [SBVR(SBVRModality.Obligatory, "دسته‌بندی کمپین‌ها", "دسته‌بندی پویش باید برای تحلیل اثربخشی و بهینه‌سازی استراتژی‌ها مشخص باشد")]
    public PromotionCategory Category { get; set; }

    public int CustomerSegmentId { get; set; }

    /// <summary>
    /// جامعه مشتریان هدف
    /// </summary>
    [DisplayName("جامعه مشتریان هدف")]
    [SBVR(SBVRModality.Obligatory, "هدف‌گذاری مشتریان", "هر پویش باید به یک جامعه مشتریان مشخص تعلق داشته باشد تا اثربخشی افزایش یابد")]
    public CustomerSegment CustomerSegment { get; set; } = null!;

    /// <summary>
    /// تاریخ شروع پویش
    /// </summary>
    [DisplayName("تاریخ شروع پویش")]
    [SBVR(SBVRModality.Recommended, "مدیریت زمان‌بندی", "تاریخ شروع پویش باید برای برنامه‌ریزی و هماهنگی با سایر کمپین‌ها مشخص باشد")]
    public DateTime? FromDate { get; set; }

    /// <summary>
    /// تاریخ پایان پویش
    /// </summary>
    [DisplayName("تاریخ پایان پویش")]
    [SBVR(SBVRModality.Recommended, "مدیریت زمان‌بندی", "تاریخ پایان پویش باید برای تحلیل دوره‌ای و برنامه‌ریزی کمپین‌های آینده مشخص باشد")]
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// نحوه شمارش پنجره زمانی پویش
    /// </summary>
    [DisplayName("نحوه شمارش پنجره زمانی")]
    [SBVR(SBVRModality.Recommended, "کنترل محدودیت‌ها", "نحوه شمارش تعیین می‌کند که چگونه تعداد دفعات استفاده محاسبه شود تا از سوءاستفاده جلوگیری شود")]
    public PromotionCounterWindowMode CounterWindowMode { get; set; }

    /// <summary>
    /// آستانه تعداد دفعات استفاده از پویش
    /// </summary>
    [DisplayName("آستانه تعداد دفعات")]
    [SBVR(SBVRModality.Recommended, "کنترل محدودیت‌ها", "آستانه تعداد دفعات تعیین می‌کند که مشتری چند بار می‌تواند از پویش استفاده کند")]
    public int? Threshold { get; set; }

    /// <summary>
    /// نوع فعال‌سازی پویش
    /// </summary>
    [DisplayName("نوع فعال‌سازی پویش")]
    [SBVR(SBVRModality.Recommended, "اتوماسیون کمپین", "نوع فعال‌سازی تعیین می‌کند که پویش چگونه فعال می‌شود تا مدیریت خودکار امکان‌پذیر باشد")]
    public PromotionTriggerKind? TriggerKind { get; set; }

    /// <summary>
    /// زمان بررسی پویش
    /// </summary>
    [DisplayName("زمان بررسی پویش")]
    [SBVR(SBVRModality.Permitted, "برنامه‌ریزی زمانی", "زمان بررسی تعیین می‌کند که پویش در چه زمانی بررسی شود تا بهینه‌سازی عملکرد امکان‌پذیر باشد")]
    public PromotionCheckTime? CheckTime { get; set; }

    /// <summary>
    /// روز هفته برای بررسی
    /// </summary>
    [DisplayName("روز هفته")]
    [SBVR(SBVRModality.Permitted, "برنامه‌ریزی زمانی", "روز هفته برای برنامه‌ریزی زمانی پویش و هماهنگی با الگوهای رفتاری مشتریان استفاده می‌شود")]
    public DayOfWeek? WeekDay { get; set; }

    /// <summary>
    /// روز ماه برای بررسی
    /// </summary>
    [DisplayName("روز ماه")]
    [SBVR(SBVRModality.Permitted, "برنامه‌ریزی زمانی", "روز ماه برای برنامه‌ریزی زمانی پویش و هماهنگی با چرخه‌های کسب‌وکار استفاده می‌شود")]
    public int? MonthDay { get; set; }

    // ===== SCHEDULING FIELDS =====

    /// <summary>
    /// آیا پویش زمان‌بندی شده است
    /// </summary>
    [DisplayName("فعال‌سازی زمان‌بندی")]
    [SBVR(SBVRModality.Permitted, "پویش زمان‌بندی شده", "برای پویش‌هایی که می‌خواهند به صورت دوره‌ای به صورت خودکار اجرا شوند")]
    public bool IsScheduled { get; set; }

    /// <summary>
    /// نوع برنامه‌ریزی برای اجرای خودکار
    /// </summary>
    [DisplayName("نوع برنامه‌ریزی")]
    [SBVR(SBVRModality.Necessary, "نوع برنامه‌ریزی", "باید تعیین شود", "وقتی زمان‌بندی فعال باشد")]
    public SchedulingKind? PromotionSchedulingKind { get; set; }

    /// <summary>
    /// ماه برای برنامه‌ریزی (1-12)
    /// </summary>
    [DisplayName("ماه")]
    [SBVR(SBVRModality.Necessary, "ماه", "باید تعیین شود", "وقتی نوع برنامه‌ریزی 'ماهانه' یا 'سالانه' باشد")]
    public int? ScheduledMonth { get; set; }

    /// <summary>
    /// ساعت انجام پویش (0-23)
    /// </summary>
    [DisplayName("ساعت")]
    [SBVR(SBVRModality.Recommended, "ساعت", "ساعت برای زمان‌بندی دقیق اجرای پویش استفاده می‌شود")]
    public int? ScheduledHour { get; set; }

    /// <summary>
    /// دقیقه انجام پویش (0-59)
    /// </summary>
    [DisplayName("دقیقه")]
    [SBVR(SBVRModality.Recommended, "دقیقه", "دقیقه برای زمان‌بندی دقیق اجرای پویش استفاده می‌شود")]
    public int? ScheduledMinute { get; set; }

    // =====================================================
    // Campaign Performance Metrics
    // =====================================================

    /// <summary>
    /// تعداد کل دریافت‌کنندگان هدف
    /// </summary>
    [DisplayName("تعداد هدف")]
    [SBVR(SBVRModality.Calculated, "تحلیل عملکرد", "تعداد هدف برای محاسبه نرخ دستیابی و بودجه‌بندی استفاده می‌شود")]
    public int? TargetAudienceCount { get; set; }

    /// <summary>
    /// تعداد پیام‌های ارسال شده
    /// </summary>
    [DisplayName("تعداد پیام‌های ارسال شده")]
    [SBVR(SBVRModality.Calculated, "تحلیل ارسال", "تعداد پیام‌های ارسال شده برای محاسبه نرخ تحویل استفاده می‌شود")]
    public int? MessagesSent { get; set; }

    /// <summary>
    /// تعداد پیام‌های تحویل شده
    /// </summary>
    [DisplayName("تعداد پیام‌های تحویل شده")]
    [SBVR(SBVRModality.Calculated, "تحلیل ارسال", "تعداد پیام‌های تحویل شده برای محاسبه نرخ تحویل استفاده می‌شود")]
    public int? MessagesDelivered { get; set; }

    /// <summary>
    /// نرخ تحویل - Delivery Rate (%)
    /// </summary>
    [DisplayName("نرخ تحویل")]
    [SBVR(SBVRModality.Calculated, "تحلیل عملکرد", "نرخ تحویل = (تحویل شده / ارسال شده) × 100")]
    public decimal? DeliveryRate { get; set; }

    /// <summary>
    /// تعداد باز شدن پیام - Open Count
    /// </summary>
    [DisplayName("تعداد باز شدن")]
    [SBVR(SBVRModality.Calculated, "تحلیل تعامل", "تعداد باز شدن برای محاسبه نرخ باز شدن استفاده می‌شود")]
    public int? OpenCount { get; set; }

    /// <summary>
    /// نرخ باز شدن - Open Rate (%)
    /// </summary>
    [DisplayName("نرخ باز شدن")]
    [SBVR(SBVRModality.Calculated, "تحلیل تعامل", "نرخ باز شدن = (باز شده / تحویل شده) × 100")]
    public decimal? OpenRate { get; set; }

    /// <summary>
    /// تعداد کلیک - Click Count
    /// </summary>
    [DisplayName("تعداد کلیک")]
    [SBVR(SBVRModality.Calculated, "تحلیل تعامل", "تعداد کلیک برای محاسبه نرخ کلیک استفاده می‌شود")]
    public int? ClickCount { get; set; }

    /// <summary>
    /// نرخ کلیک - Click-Through Rate (%)
    /// </summary>
    [DisplayName("نرخ کلیک")]
    [SBVR(SBVRModality.Calculated, "تحلیل تعامل", "نرخ کلیک = (کلیک شده / باز شده) × 100")]
    public decimal? ClickThroughRate { get; set; }

    /// <summary>
    /// تعداد تبدیل‌ها - Conversion Count
    /// </summary>
    [DisplayName("تعداد تبدیل")]
    [SBVR(SBVRModality.Calculated, "تحلیل نتایج", "تعداد تبدیل برای محاسبه نرخ تبدیل و ROI استفاده می‌شود")]
    public int? ConversionCount { get; set; }

    /// <summary>
    /// نرخ تبدیل - Conversion Rate (%)
    /// </summary>
    [DisplayName("نرخ تبدیل")]
    [SBVR(SBVRModality.Calculated, "تحلیل نتایج", "نرخ تبدیل = (تبدیل شده / هدف) × 100")]
    public decimal? ConversionRate { get; set; }

    // =====================================================
    // Financial Metrics
    // =====================================================

    /// <summary>
    /// هزینه کمپین - Campaign Cost
    /// </summary>
    [DisplayName("هزینه کمپین")]
    [SBVR(SBVRModality.Recommended, "تحلیل مالی", "هزینه کمپین برای محاسبه ROI و CAC استفاده می‌شود")]
    public decimal? CampaignCost { get; set; }

    /// <summary>
    /// درآمد حاصل از کمپین - Campaign Revenue
    /// </summary>
    [DisplayName("درآمد کمپین")]
    [SBVR(SBVRModality.Calculated, "تحلیل مالی", "درآمد کمپین برای محاسبه ROI و سودآوری استفاده می‌شود")]
    public decimal? CampaignRevenue { get; set; }

    /// <summary>
    /// بازگشت سرمایه - ROI (%)
    /// </summary>
    [DisplayName("بازگشت سرمایه (ROI)")]
    [SBVR(SBVRModality.Calculated, "تحلیل سودآوری", "ROI = ((درآمد - هزینه) / هزینه) × 100")]
    public decimal? ReturnOnInvestment { get; set; }

    /// <summary>
    /// هزینه جذب مشتری - Customer Acquisition Cost
    /// </summary>
    [DisplayName("هزینه جذب مشتری (CAC)")]
    [SBVR(SBVRModality.Calculated, "تحلیل بهره‌وری", "CAC = هزینه کمپین / تعداد مشتریان جذب شده")]
    public decimal? CustomerAcquisitionCost { get; set; }

    /// <summary>
    /// هزینه هر تبدیل - Cost Per Conversion
    /// </summary>
    [DisplayName("هزینه هر تبدیل")]
    [SBVR(SBVRModality.Calculated, "تحلیل بهره‌وری", "هزینه هر تبدیل = هزینه کمپین / تعداد تبدیل‌ها")]
    public decimal? CostPerConversion { get; set; }

    // =====================================================
    // Engagement Metrics
    // =====================================================

    /// <summary>
    /// تعداد مشتریان جدید جذب شده
    /// </summary>
    [DisplayName("تعداد مشتریان جدید")]
    [SBVR(SBVRModality.Calculated, "تحلیل جذب", "تعداد مشتریان جدید برای محاسبه CAC و تحلیل اثربخشی استفاده می‌شود")]
    public int? NewCustomersAcquired { get; set; }

    /// <summary>
    /// نمره اثربخشی - Effectiveness Score (0-100)
    /// </summary>
    [DisplayName("نمره اثربخشی")]
    [SBVR(SBVRModality.Calculated, "تحلیل کلی", "نمره اثربخشی برای مقایسه کمپین‌ها و اولویت‌بندی استفاده می‌شود")]
    public decimal? EffectivenessScore { get; set; }

    /// <summary>
    /// تاریخ آخرین محاسبه معیارها
    /// </summary>
    [DisplayName("تاریخ آخرین محاسبه")]
    [SBVR(SBVRModality.Calculated, "مدیریت داده", "تاریخ آخرین محاسبه برای اطمینان از به‌روز بودن معیارها استفاده می‌شود")]
    public DateTime? LastMetricsCalculationDate { get; set; }

    /// <summary>
    /// وضعیت کمپین - Active, Paused, Completed, Cancelled
    /// </summary>
    [DisplayName("وضعیت کمپین")]
    [MaxLength(20)]
    [SBVR(SBVRModality.Recommended, "مدیریت چرخه حیات", "وضعیت کمپین برای مدیریت و گزارش‌گیری استفاده می‌شود")]
    public string? CampaignStatus { get; set; }
}