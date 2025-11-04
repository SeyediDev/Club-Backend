namespace Club.Domain.Entities.Customers;

[DisplayName("سازمان بهره‌بردار")]
[SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر سازمان باید برای جداسازی داده‌ها، مدیریت دسترسی و تحلیل عملکرد مستقل قابل شناسایی باشد")]
[SBVR(SBVRModality.Recommended, "چندین سازمان", "سازمان‌ها باید برای مدیریت چندین مشتری، محصول و کمپین‌های بازاریابی طراحی شوند")]
public class Tenant : ClubBaseCoreConfigAuditableEntity<int>
{
    /// <summary>
    /// عنوان سازمان
    /// </summary>
    [DisplayName("عنوان سازمان")]
    [InDisplayString]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "شناسایی سازمان", "عنوان سازمان باید برای نمایش در رابط کاربری و گزارش‌ها واضح و قابل فهم باشد")]
    public string Title { get; set; } = null!;

    /// <summary>
    /// کلید API سازمان
    /// </summary>
    [DisplayName("کلید API سازمان")]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "امنیت API", "کلید API باید برای احراز هویت و دسترسی امن به خدمات سیستم منحصر به فرد باشد")]
    public string ApiKey { get; set; } = null!;
}