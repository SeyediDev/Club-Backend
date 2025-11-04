namespace Club.Domain.Entities.Events;

/// <summary>
/// تنوع کانال تولید کننده رویداد را اینجا لیست می کنیم
/// 1 - باجت
/// 2 - DigiPay
/// 3 - سوییچ
/// 4 - هوش مصنوعی
/// 4 - نوا
/// 10 - همراه بانک
/// </summary>
[DisplayName("کانال دریافت رویداد")]
public class EventChannel : ClubBaseCoreConfigAuditableEntity<int>
{
    [MaxLength(40)]
    [DisplayName("کلید")]
    public string Key { get; set; } = null!;

    //[Unique]
    [DisplayName("عنوان")]
    [InDisplayString]
    [MaxLength(41)]
    public string Title { get; set; } = null!;
}
