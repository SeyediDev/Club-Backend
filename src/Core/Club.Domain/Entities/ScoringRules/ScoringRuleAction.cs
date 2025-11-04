using Club.Domain.Entities.Rewards;

namespace Club.Domain.Entities.ScoringRules;

/// <summary>
/// عملیاتی که به ازای یک رول انجام می شود.
/// </summary>
[DisplayName("عملیات قانون‌امتیازدهی")]
public class ScoringRuleAction : ClubBaseCoreConfigAuditableEntity<int>
{
    public int ScoringRuleId { get; set; }
    [DisplayName("قانون‌امتیازدهی")]
    public ScoringRule ScoringRule { get; set; } = null!;

    [DisplayName("چه کسی")]
    public ScoringRuleActionOnWho ActionOnWho { get; set; }
    
    [DisplayName("نوع عملیات")]
    public ScoringRuleActionKind ActionKind { get; set; }
    
    [DisplayName("روش اطلاع رسانی")]
    public ScoringRuleNotificationMethod NotificationMethod { get; set; }

    public int? PointId { get; set; }
    [DisplayName("امتیاز")]
    public Point? Point { get; set; }

    [OldDbMap("ProductId")]
    public int? AwardId { get; set; }
    [DisplayName("پاداش")]
    [SBVR(SBVRModality.Permitted, "اعطای پاداش", "پاداش برای تعریف پاداشی که به مشتری اعطا می‌شود استفاده می‌شود")]
    public Reward? Award { get; set; }

    public int? TenantProductOrServiceId { get; set; }
    [DisplayName("محصول سازمان")]
    [SBVR(SBVRModality.Permitted, "اعطای محصول", "محصول سازمان برای تعریف محصول یا خدمتی که مشتری می‌تواند خریداری کند و امتیاز کسب کند استفاده می‌شود")]
    public Product? TenantProductOrService { get; set; }

    public int? CustomerSegmentId { get; set; }
    [DisplayName("جامعه مشتریان")]
    public CustomerSegment? CustomerSegment { get; set; }

    [DisplayName("ترتیب")]
    public int? Order { get; set; }

    //TODO کاربرد این فیلد چک شود
    public int? CustomerParameterId { get; set; }
    [DisplayName("پارامتر مشتری")]
    public CustomerParameter? CustomerParameter { get; set; }

    [DisplayName("روش محاسبه مقدار")]
    public ScoringRuleActionAmountMethod AmountMethod { get; set; }

    public int? AmountParameterId { get; set; }
    [DisplayName("پارامتر مقدار")]
    //TODO رول مناسب برای فیلتر کردن پارامتر مقدار
    //[Filter("ScoringRule.EventTypeId=EventTypeParameter.EventTypeId")]
    public EventTypeParameter? AmountParameter { get; set; }

    [DisplayName("مقدار ثابت")]
    [MaxLength(512)]
    public string? Amount { get; set; }

    [DisplayName("فرمول مقدار")]
    [MaxLength(512)]
    public string? AmountFormula { get; set; } = null!;

    [DisplayName("تمپلیت پیام")]
    [MaxLength(512)]
    public string? MessageTemplate { get; set; } = null!;
}
