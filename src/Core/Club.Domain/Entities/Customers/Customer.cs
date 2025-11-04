namespace Club.Domain.Entities.Customers;

[DisplayName("مشتری")]
[SBVR(SBVRModality.Obligatory, "مدیریت مشتریان", "هر مشتری باید برای امتیازدهی، تراکنش‌ها، تحلیل RFM و کمپین‌های بازاریابی قابل شناسایی باشد")]
[SBVR(SBVRModality.Recommended, "مدیریت مشتریان", "اطلاعات مشتری باید برای محاسبه Customer Lifetime Value، تحلیل رفتار و شخصی‌سازی خدمات کامل باشد")]
public partial class Customer : ClubBaseCoreAuditableEntity<int>
{
    /// <summary>
    /// نام
    /// </summary>
    [DisplayName("نام")]
    [InDisplayString] 
    [MaxLength(61)]
    [SBVR(SBVRModality.Recommended, "شناسایی مشتری", "نام برای شخصی‌سازی پیام‌ها و تحلیل جمعیت‌شناختی ضروری است")]
    public string? FirstName { get; set; }

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    [DisplayName("نام خانوادگی")]
    [InDisplayString] 
    [MaxLength(61)]
    [SBVR(SBVRModality.Recommended, "شناسایی مشتری", "نام خانوادگی برای تکمیل پروفایل و تحلیل خانواده‌ها مهم است")]
    public string? LastName { get; set; }

    /// <summary>
    /// کد ملی
    /// </summary>
    [DisplayName("کد ملی")]
    [SBVR(SBVRModality.Recommended, "شناسایی یکتا", "کد ملی برای جلوگیری از ثبت تکراری و تحلیل جمعیت‌شناختی استفاده می‌شود")]
    public long? NationalCode { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    [DisplayName("شماره موبایل")]
    [MaxLength(14)]
    [SBVR(SBVRModality.Obligatory, "ارتباط با مشتری", "شماره موبایل برای ارسال پیامک‌های کمپین، اطلاع‌رسانی و احراز هویت ضروری است")]
    public string? MobileNo { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// </summary>
    [DisplayName("تاریخ تولد")]
    [SBVR(SBVRModality.Recommended, "تحلیل جمعیت‌شناختی", "تاریخ تولد برای کمپین‌های سنی، تحلیل رفتار و شخصی‌سازی خدمات استفاده می‌شود")]
    public DateTime? BirthDate { get; set; }

    // =====================================================
    // RFM Analysis Fields
    // =====================================================

    /// <summary>
    /// Recency - تاریخ آخرین خرید/تعامل
    /// </summary>
    [DisplayName("آخرین تعامل")]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "تاریخ آخرین تعامل برای محاسبه Recency Score و تحلیل رفتار مشتری استفاده می‌شود")]
    public DateTime? LastInteractionDate { get; set; }

    /// <summary>
    /// Recency Score - نمره تازگی (1-5)
    /// </summary>
    [DisplayName("نمره تازگی")]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "نمره تازگی برای دسته‌بندی مشتریان بر اساس میزان اخیر بودن تعامل استفاده می‌شود")]
    public int? RecencyScore { get; set; }

    /// <summary>
    /// Frequency - تعداد تراکنش‌ها/تعاملات
    /// </summary>
    [DisplayName("تعداد تعاملات")]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "تعداد تعاملات برای محاسبه Frequency Score و تحلیل میزان فعالیت مشتری استفاده می‌شود")]
    public int? TotalInteractions { get; set; }

    /// <summary>
    /// Frequency Score - نمره تکرار (1-5)
    /// </summary>
    [DisplayName("نمره تکرار")]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "نمره تکرار برای دسته‌بندی مشتریان بر اساس میزان تکرار تعاملات استفاده می‌شود")]
    public int? FrequencyScore { get; set; }

    /// <summary>
    /// Monetary - ارزش کل تراکنش‌ها
    /// </summary>
    [DisplayName("ارزش کل تراکنش‌ها")]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "ارزش کل تراکنش‌ها برای محاسبه Monetary Score و تحلیل ارزش مشتری استفاده می‌شود")]
    public decimal? TotalTransactionValue { get; set; }

    /// <summary>
    /// Monetary Score - نمره ارزش (1-5)
    /// </summary>
    [DisplayName("نمره ارزش")]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "نمره ارزش برای دسته‌بندی مشتریان بر اساس میزان ارزش مالی استفاده می‌شود")]
    public int? MonetaryScore { get; set; }

    /// <summary>
    /// RFM Segment - دسته RFM (e.g., "Champions", "Loyal", "At Risk")
    /// </summary>
    [DisplayName("دسته RFM")]
    [MaxLength(50)]
    [SBVR(SBVRModality.Calculated, "تحلیل RFM", "دسته RFM برای دسته‌بندی مشتریان و هدف‌گذاری کمپین‌ها استفاده می‌شود")]
    public string? RfmSegment { get; set; }

    // =====================================================
    // Customer Lifetime Value (CLV) Fields
    // =====================================================

    /// <summary>
    /// Customer Lifetime Value - ارزش طول عمر مشتری
    /// </summary>
    [DisplayName("ارزش طول عمر مشتری")]
    [SBVR(SBVRModality.Calculated, "تحلیل CLV", "ارزش طول عمر مشتری برای تحلیل سودآوری و اولویت‌بندی مشتریان استفاده می‌شود")]
    public decimal? CustomerLifetimeValue { get; set; }

    /// <summary>
    /// Average Order Value - میانگین ارزش سفارش
    /// </summary>
    [DisplayName("میانگین ارزش سفارش")]
    [SBVR(SBVRModality.Calculated, "تحلیل رفتار خرید", "میانگین ارزش سفارش برای تحلیل رفتار خرید و پیش‌بینی درآمد استفاده می‌شود")]
    public decimal? AverageOrderValue { get; set; }

    /// <summary>
    /// Purchase Frequency - تعداد خریدها در واحد زمان
    /// </summary>
    [DisplayName("فرکانس خرید")]
    [SBVR(SBVRModality.Calculated, "تحلیل رفتار خرید", "فرکانس خرید برای پیش‌بینی رفتار آینده و برنامه‌ریزی کمپین‌ها استفاده می‌شود")]
    public decimal? PurchaseFrequency { get; set; }

    // =====================================================
    // Engagement & Loyalty Fields
    // =====================================================

    /// <summary>
    /// Engagement Score - نمره تعامل مشتری (0-100)
    /// </summary>
    [DisplayName("نمره تعامل")]
    [SBVR(SBVRModality.Calculated, "تحلیل تعامل", "نمره تعامل برای سنجش میزان مشارکت مشتری در فعالیت‌های باشگاه استفاده می‌شود")]
    public decimal? EngagementScore { get; set; }

    /// <summary>
    /// Loyalty Score - نمره وفاداری (0-100)
    /// </summary>
    [DisplayName("نمره وفاداری")]
    [SBVR(SBVRModality.Calculated, "تحلیل وفاداری", "نمره وفاداری برای شناسایی مشتریان وفادار و برنامه‌ریزی استراتژی‌های حفظ مشتری استفاده می‌شود")]
    public decimal? LoyaltyScore { get; set; }

    /// <summary>
    /// Churn Risk Score - نمره احتمال ریزش (0-100)
    /// </summary>
    [DisplayName("نمره احتمال ریزش")]
    [SBVR(SBVRModality.Calculated, "تحلیل ریزش", "نمره احتمال ریزش برای شناسایی مشتریان در معرض خطر ریزش و اجرای کمپین‌های حفظ مشتری استفاده می‌شود")]
    public decimal? ChurnRiskScore { get; set; }

    /// <summary>
    /// NPS Score - Net Promoter Score (-100 to 100)
    /// </summary>
    [DisplayName("نمره NPS")]
    [SBVR(SBVRModality.Recommended, "تحلیل رضایت", "نمره NPS برای سنجش احتمال توصیه مشتری به دیگران استفاده می‌شود")]
    public int? NpsScore { get; set; }

    /// <summary>
    /// Satisfaction Score - نمره رضایت (0-100)
    /// </summary>
    [DisplayName("نمره رضایت")]
    [SBVR(SBVRModality.Recommended, "تحلیل رضایت", "نمره رضایت برای سنجش میزان رضایت کلی مشتری استفاده می‌شود")]
    public decimal? SatisfactionScore { get; set; }

    // =====================================================
    // Status & Activity Fields
    // =====================================================

    /// <summary>
    /// Is Active Customer - آیا مشتری فعال است
    /// </summary>
    [DisplayName("مشتری فعال")]
    [SBVR(SBVRModality.Calculated, "وضعیت فعالیت", "وضعیت فعالیت مشتری برای فیلتر کردن و تحلیل مشتریان فعال استفاده می‌شود")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// تاریخ اولین خرید/تعامل
    /// </summary>
    [DisplayName("تاریخ اولین تعامل")]
    [SBVR(SBVRModality.Calculated, "تحلیل چرخه حیات", "تاریخ اولین تعامل برای محاسبه طول عمر مشتری و تحلیل روند رشد استفاده می‌شود")]
    public DateTime? FirstInteractionDate { get; set; }

    /// <summary>
    /// Days Since Last Interaction - تعداد روز از آخرین تعامل
    /// </summary>
    [DisplayName("روز از آخرین تعامل")]
    [SBVR(SBVRModality.Calculated, "تحلیل فعالیت", "تعداد روز از آخرین تعامل برای شناسایی مشتریان غیرفعال و برنامه‌ریزی کمپین‌های فعال‌سازی مجدد استفاده می‌شود")]
    public int? DaysSinceLastInteraction { get; set; }

    /// <summary>
    /// Total Points Earned - مجموع امتیازات کسب شده
    /// </summary>
    [DisplayName("مجموع امتیازات کسب شده")]
    [SBVR(SBVRModality.Calculated, "تحلیل امتیازات", "مجموع امتیازات کسب شده برای تحلیل میزان مشارکت در برنامه وفاداری استفاده می‌شود")]
    public long? TotalPointsEarned { get; set; }

    /// <summary>
    /// Total Points Redeemed - مجموع امتیازات استفاده شده
    /// </summary>
    [DisplayName("مجموع امتیازات استفاده شده")]
    [SBVR(SBVRModality.Calculated, "تحلیل امتیازات", "مجموع امتیازات استفاده شده برای تحلیل میزان استفاده از پاداش‌ها استفاده می‌شود")]
    public long? TotalPointsRedeemed { get; set; }

    /// <summary>
    /// Current Points Balance - موجودی فعلی امتیازات
    /// </summary>
    [DisplayName("موجودی فعلی امتیازات")]
    [SBVR(SBVRModality.Calculated, "تحلیل امتیازات", "موجودی فعلی امتیازات برای نمایش به مشتری و تحلیل ارزش باقیمانده استفاده می‌شود")]
    public long? CurrentPointsBalance { get; set; }
}