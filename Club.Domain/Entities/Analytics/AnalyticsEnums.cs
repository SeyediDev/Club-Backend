namespace Club.Domain.Entities.Analytics;

/// <summary>
/// دوره تحلیل - تعیین دوره زمانی تحلیل
/// </summary>
public enum AnalysisPeriod
{
    /// <summary>
    /// روزانه
    /// </summary>
    Daily = 1,

    /// <summary>
    /// هفتگی
    /// </summary>
    Weekly = 2,

    /// <summary>
    /// ماهانه
    /// </summary>
    Monthly = 3,

    /// <summary>
    /// فصلی
    /// </summary>
    Quarterly = 4,

    /// <summary>
    /// سالانه
    /// </summary>
    Yearly = 5,

    /// <summary>
    /// سفارشی
    /// </summary>
    Custom = 6
}

/// <summary>
/// بخش RFM - بخش‌بندی مشتری بر اساس نمره RFM
/// </summary>
public enum RFMSegment
{
    /// <summary>
    /// چمپیون - مشتریان با ارزش بالا و وفادار
    /// </summary>
    Champions = 1,

    /// <summary>
    /// وفاداران - مشتریان وفادار با ارزش متوسط
    /// </summary>
    LoyalCustomers = 2,

    /// <summary>
    /// پتانسیل بالا - مشتریان با پتانسیل رشد بالا
    /// </summary>
    PotentialLoyalists = 3,

    /// <summary>
    /// جدید - مشتریان جدید
    /// </summary>
    NewCustomers = 4,

    /// <summary>
    /// در خطر - مشتریان در خطر ترک
    /// </summary>
    AtRisk = 5,

    /// <summary>
    /// نمی‌توان نگه داشت - مشتریان با ارزش پایین
    /// </summary>
    CannotLoseThem = 6,

    /// <summary>
    /// خوابیده - مشتریان غیرفعال
    /// </summary>
    Hibernating = 7,

    /// <summary>
    /// از دست رفته - مشتریان ترک کرده
    /// </summary>
    Lost = 8
}
