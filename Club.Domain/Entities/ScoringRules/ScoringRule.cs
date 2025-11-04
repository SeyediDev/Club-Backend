namespace Club.Domain.Entities.ScoringRules;

[DisplayName("قانون امتیازدهی")]
[SBVR(SBVRModality.Obligatory, "اتوماسیون امتیازدهی", "هر قانون امتیازدهی باید برای تشویق رفتارهای مطلوب مشتریان و افزایش وفاداری قابل اجرا باشد")]
[SBVR(SBVRModality.Recommended, "اتوماسیون امتیازدهی", "قوانین باید برای تحلیل اثربخشی کمپین‌ها و بهینه‌سازی استراتژی‌های بازاریابی طراحی شوند")]
public class ScoringRule : ClubBaseCoreConfigAuditableEntity<int>
{
    /// <summary>
    /// شناسه سازمان بهره‌بردار
    /// </summary>
    [DisplayName("شناسه سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر قانون امتیازدهی باید به یک سازمان مشخص تعلق داشته باشد تا از تداخل قوانین جلوگیری شود")]
    public int TenantId { get; set; }

    /// <summary>
    /// سازمان بهره‌بردار
    /// </summary>
    [DisplayName("سازمان بهره‌بردار")]
    [SBVR(SBVRModality.Obligatory, "چندین سازمان", "هر قانون امتیازدهی باید به یک سازمان مشخص تعلق داشته باشد تا از تداخل قوانین جلوگیری شود")]
    public Tenant Tenant { get; set; } = null!;

    /// <summary>
    /// عنوان قانون
    /// </summary>
    [DisplayName("عنوان قانون")]
    [InDisplayString]
    [MaxLength(41)]
    [SBVR(SBVRModality.Obligatory, "شناسایی قانون", "عنوان قانون باید برای مدیریت و ردیابی قوانین امتیازدهی واضح و قابل فهم باشد")]
    public string Title { get; set; } = null!;
}