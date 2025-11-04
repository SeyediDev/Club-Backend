namespace Club.Domain.Entities.Promotions;

/// <summary>
/// نوع پیام پویش - تعیین نوع پیام
/// </summary>
public enum PromotionMessageType
{
    /// <summary>
    /// تبلیغاتی
    /// </summary>

    Promotional = 1,

    /// <summary>
    /// اطلاع‌رسانی
    /// </summary>

    Informational = 2,

    /// <summary>
    /// تعاملی
    /// </summary>

    Interactive = 3,

    /// <summary>
    /// تبریک
    /// </summary>

    Congratulatory = 4,

    /// <summary>
    /// یادآوری
    /// </summary>

    Reminder = 5,

    /// <summary>
    /// دعوت
    /// </summary>

    Invitation = 6,

    /// <summary>
    /// نظرسنجی
    /// </summary>

    Survey = 7,

    /// <summary>
    /// سفارشی
    /// </summary>

    Custom = 8
}

/// <summary>
/// وضعیت پیام پویش - وضعیت فعلی پیام
/// </summary>
public enum PromotionMessageStatus
{
    /// <summary>
    /// پیش‌نویس
    /// </summary>

    Draft = 1,

    /// <summary>
    /// آماده ارسال
    /// </summary>

    ReadyToSend = 2,

    /// <summary>
    /// در حال ارسال
    /// </summary>

    Sending = 3,

    /// <summary>
    /// ارسال شده
    /// </summary>

    Sent = 4,

    /// <summary>
    /// تحویل شده
    /// </summary>

    Delivered = 5,

    /// <summary>
    /// خوانده شده
    /// </summary>

    Read = 6,

    /// <summary>
    /// ناموفق
    /// </summary>

    Failed = 7,

    /// <summary>
    /// لغو شده
    /// </summary>

    Cancelled = 8
}

/// <summary>
/// وضعیت گیرنده پویش - وضعیت فعلی گیرنده
/// </summary>
public enum PromotionRecipientStatus
{
    /// <summary>
    /// در انتظار ارسال
    /// </summary>

    Pending = 1,

    /// <summary>
    /// در حال ارسال
    /// </summary>

    Sending = 2,

    /// <summary>
    /// ارسال شده
    /// </summary>

    Sent = 3,

    /// <summary>
    /// تحویل شده
    /// </summary>

    Delivered = 4,

    /// <summary>
    /// خوانده شده
    /// </summary>

    Read = 5,

    /// <summary>
    /// پاسخ داده شده
    /// </summary>

    Responded = 6,

    /// <summary>
    /// ناموفق
    /// </summary>

    Failed = 7,

    /// <summary>
    /// لغو شده
    /// </summary>

    Cancelled = 8
}
