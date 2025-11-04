namespace Club.Domain.Entities.ScoringRules;

public enum ScoringRuleNotificationMethod
{
    [Description("بدون اطلاع رسانی")]
    None = 0,
    [Description("ارسال پیامک")]
    SendSms = 1,
    [Description("ارسال نوتیفیکیشن")]
    SendNotification = 2,
    [Description("هر دو")]
    Both = 3,
}