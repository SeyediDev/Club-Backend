namespace Club.Domain.Entities.Promotions;

/// <summary>
/// قرعه‌کشی - سیستم قرعه‌کشی برای اهدای پاداش‌ها به مشتریان
/// قرعه‌کشی می‌تواند به صورت چرخونه (کاربر درخواست می‌دهد) یا زمان‌بندی شده (خودکار در زمان مشخص) باشد
/// </summary>
[DisplayName("قرعه‌کشی")]
[SBVR(SBVRModality.Obligatory, "مدیریت قرعه‌کشی", "هر قرعه‌کشی باید برای تعیین پاداش‌ها، نرخ برنده شدن و مدیریت شرکت‌کنندگان قابل شناسایی باشد")]
[SBVR(SBVRModality.Recommended, "مدیریت قرعه‌کشی", "قرعه‌کشی‌ها باید برای افزایش تعامل مشتریان، تشویق خرید و رقابت مثبت استفاده شوند")]
[SBVR(SBVRModality.Permitted, "انواع قرعه‌کشی", "قرعه‌کشی‌ها می‌توانند چرخونه (فوری) یا زمان‌بندی شده (خودکار) باشند")]
public class Lottery : ClubBaseCoreConfigAuditableEntity<int>
{
    /// <summary>
    /// شناسه سازمان بهره‌بردار
    /// </summary>
    [DisplayName("سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر قرعه‌کشی باید به یک سازمان مشخص تعلق داشته باشد تا از تداخل داده‌ها جلوگیری شود")]
    public int TenantId { get; set; }

    /// <summary>
    /// سازمان بهره‌بردار
    /// </summary>
    [DisplayName("سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر قرعه‌کشی باید به یک سازمان مشخص تعلق داشته باشد")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// عنوان قرعه‌کشی
    /// </summary>
    [DisplayName("عنوان")]
    [InDisplayString]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "شناسایی قرعه‌کشی", "عنوان برای نمایش به مشتریان و مدیریت قرعه‌کشی‌ها ضروری است")]
    [SBVR(SBVRModality.Recommended, "شناسایی قرعه‌کشی", "عنوان باید واضح و جذاب باشد تا مشتریان را به شرکت ترغیب کند")]
    public string Title { get; set; } = null!;

    public int? CustomerSegmentId { get; set; }
    [DisplayName("جامعه مشتریان")]
    [SBVR(SBVRModality.Permitted, "جامعه مشتریان", "اگر قرعه‌کشی فقط برای یک جامعه خاص باشد تعیین می‌شود")]
    public CustomerSegment? CustomerSegment { get; set; } = null!;

    /// <summary>
    /// نوع قرعه‌کشی: چرخونه یا زمان‌بندی شده
    /// </summary>
    [DisplayName("نوع قرعه‌کشی")]
    [SBVR(SBVRModality.Obligatory, "نوع قرعه‌کشی", "نوع قرعه‌کشی تعیین می‌کند که آیا چرخونه انجام می‌شود یا زمان‌بندی شده")]
    public LotteryType LotteryType { get; set; } = LotteryType.Wheel;

    [DisplayName("از تاریخ")]
    [SBVR(SBVRModality.Recommended, "تاریخ شروع", "تاریخ شروع برای قرعه‌کشی‌های زمان‌بندی شده استفاده می‌شود")]
    public DateTime? FromDate { get; set; }

    [DisplayName("تا تاریخ")]
    [SBVR(SBVRModality.Recommended, "تاریخ پایان", "تاریخ پایان برای قرعه‌کشی‌های زمان‌بندی شده استفاده می‌شود")]
    public DateTime? ToDate { get; set; }

    // ===== SCHEDULING FIELDS =====
    
    /// <summary>
    /// آیا برنامه‌ریزی فعال است
    /// </summary>
    [DisplayName("فعال‌سازی برنامه‌ریزی")]
    [SBVR(SBVRModality.Permitted, "برنامه‌ریزی زمان‌بندی", "برای قرعه‌کشی‌های زمان‌بندی شده استفاده می‌شود")]
    public bool IsScheduled { get; set; }

    /// <summary>
    /// نوع پنجره زمانی برنامه‌ریزی
    /// </summary>
    [DisplayName("نوع برنامه‌ریزی")]
    [SBVR(SBVRModality.Necessary, "نوع برنامه‌ریزی", "باید تعیین شود", "وقتی برنامه‌ریزی فعال باشد")]
    public SchedulingKind? SchedulingKind { get; set; }

    /// <summary>
    /// روز هفته برای برنامه‌ریزی (1=شنبه تا 7=جمعه)
    /// </summary>
    [DisplayName("روز هفته")]
    [SBVR(SBVRModality.Necessary, "روز هفته", "باید تعیین شود", "وقتی نوع برنامه‌ریزی 'روز هفته' باشد")]
    public int? DayOfWeek { get; set; }

    /// <summary>
    /// روز ماه برای برنامه‌ریزی (1-31)
    /// </summary>
    [DisplayName("روز ماه")]
    [SBVR(SBVRModality.Necessary, "روز ماه", "باید تعیین شود", "وقتی نوع برنامه‌ریزی 'روز ماه' باشد")]
    public int? DayOfMonth { get; set; }

    /// <summary>
    /// ماه برای برنامه‌ریزی (1-12)
    /// </summary>
    [DisplayName("ماه")]
    [SBVR(SBVRModality.Necessary, "ماه", "باید تعیین شود", "وقتی نوع برنامه‌ریزی 'ماهانه' باشد")]
    public int? Month { get; set; }

    /// <summary>
    /// روز سال برای برنامه‌ریزی (1-365)
    /// </summary>
    [DisplayName("روز سال")]
    [SBVR(SBVRModality.Necessary, "روز سال", "باید تعیین شود", "وقتی نوع برنامه‌ریزی 'سالیانه' باشد")]
    public int? DayOfYear { get; set; }

    /// <summary>
    /// ساعت انجام قرعه‌کشی (0-23)
    /// </summary>
    [DisplayName("ساعت")]
    [SBVR(SBVRModality.Recommended, "ساعت", "ساعت انجام قرعه‌کشی برای زمان‌بندی استفاده می‌شود")]
    public int? Hour { get; set; }

    /// <summary>
    /// دقیقه انجام قرعه‌کشی (0-59)
    /// </summary>
    [DisplayName("دقیقه")]
    [SBVR(SBVRModality.Recommended, "دقیقه", "دقیقه انجام قرعه‌کشی برای زمان‌بندی استفاده می‌شود")]
    public int? Minute { get; set; }

    /// <summary>
    /// رابط‌های Navigation
    /// </summary>
    [DisplayName("پاداش‌های قرعه‌کشی")]
    public ICollection<LotteryReward> LotteryRewards { get; set; } = new List<LotteryReward>();

    [DisplayName("شرکت‌کنندگان")]
    public ICollection<LotteryParticipant> Participants { get; set; } = new List<LotteryParticipant>();
}

/// <summary>
/// نوع قرعه‌کشی
/// </summary>
public enum LotteryType
{
    [Description("چرخونه - کاربر درخواست می‌دهد و فوراً قرعه‌کشی می‌شود")]
    Wheel = 1,
    
    [Description("زمان‌بندی شده - قرعه‌کشی خودکار در زمان مشخص")]
    Scheduled = 2
}

/// <summary>
/// نوع برنامه‌ریزی زمان‌بندی
/// </summary>
public enum SchedulingKind
{
    [Description("هر ساعت")]
    Hourly = 1,
    
    [Description("روزانه")]
    Daily = 2,
    
    [Description("هفتگی")]
    Weekly = 3,
    
    [Description("ماهانه")]
    Monthly = 4,
    
    [Description("سالانه")]
    Yearly = 5
}
