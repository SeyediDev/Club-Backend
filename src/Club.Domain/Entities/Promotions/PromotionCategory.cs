namespace Club.Domain.Entities.Promotions;

public enum PromotionCategory : int
{
    /// <summary>
    /// تقویت حس تعلق به یک جامعه خاص.
    /// </summary>
    [Description("رویدادهای ملی")]
    NationalEvents=1,

    /// <summary>
    /// تقویت حس تعلق به یک جامعه خاص.
    /// </summary>
    [Description("رویدادهای مذهبی")]
    ReligiousEvents,

    /// <summary>
    /// تقویت حس تعلق به یک جامعه خاص.
    /// مثلا سالروز نصب باجت
    /// مثلا سالروز افتتاح حساب
    /// </summary>
    [Description("رویدادهای فرد")]
    IndividualEvents,

    /// <summary>
    /// تقویت حس تعلق به یک جامعه خاص.
    /// مثلا سالروز نصب باجت
    /// مثلا سالروز افتتاح حساب
    /// </summary>
    [Description("رویدادهای فرد در جامعه ما")]
    IndividualEventsInOwn,

    /// <summary>
    /// ایجاد یک ارتباط عاطفی قوی و شخصی‌سازی شده.
    /// </summary>
    [Description("هدایای روز تولد")]
    BirthdayGifts,

    /// <summary>
    /// ایجاد هیجان و تعامل و همچنین جمع‌آوری داده.
    /// </summary>
    [Description("هدایا")]
    Giveaways,

    /// <summary>
                              /// کلاسیک‌ترین و محبوب‌ترین نوع پروموشن. فقط برای اعضا
                              /// </summary>
    [Description("تخفیف های انحصاری")]
    ExclusiveDiscounts,

    /// <summary>
    /// پیشنهادهایی که خارج از باشگاه قابل دسترسی نیستند.
    /// </summary>
    [Description("پیشنهادهای ویژه")]
    SpecialOffers,

    /// <summary>
    /// سیستم پاداش برای خریدها و فعالیت‌های مختلف.
    /// </summary>
    [Description("برنامه‌های پاداش و امتیازی")]
    PointPoint,

    /// <summary>
    /// ایجاد احساس ویژه و انحصاری بودن.
    /// </summary>
    [Description("دسترسی زودهنگام یا پیش‌فروش")]
    EarlyAccess,

    /// <summary>
    /// ایجاد هیجان و تعامل و همچنین جمع‌آوری داده.
    /// </summary>
    [Description("مسابقات")]
    Contests,
}
