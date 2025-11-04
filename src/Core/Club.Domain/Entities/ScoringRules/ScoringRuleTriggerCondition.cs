using Club.Domain.Entities.Rewards;

namespace Club.Domain.Entities.ScoringRules;

/// <summary>
/// شرایطی که باعث می شود این رول اعمال شود
/// باید بتوان ویندوزهای تعدادی و زمانی تعریف کرد
/// </summary>
[DisplayName("شرط فراخوانی قانون‌امتیازدهی")]
public class ScoringRuleTriggerCondition : ClubBaseCoreConfigAuditableEntity<int>
{
    public int ScoringRuleId { get; set; }
    [DisplayName("قانون‌امتیازدهی")]
    public ScoringRule ScoringRule { get; set; } = null!;

    [DisplayName("عنوان")]
    [InDisplayString]
    [MaxLength(41)]
    public string Title { get; set; } = null!;

    [DisplayName("نوع‌فراخوانی")]
    public TriggerType TriggerType { get; set; }

    /// <summary>
    /// For TriggerType.Event
    /// </summary>
    public int? EventChannelId { get; set; }
    [DisplayName("صادرکننده رویداد")]
    public EventChannel? EventChannel { get; set; }

    /// <summary>
    /// For TriggerType.Event
    /// </summary>
    public int? EventTypeId { get; set; }
    [DisplayName("رویداد")]
    public EventType? EventType { get; set; }

    /// <summary>
    /// For TriggerType.UpgradePointLevel
    /// </summary>
    public int? PointLevelId { get; set; }
    [DisplayName("سطح‌امتیاز")]
    public PointLevel? PointLevel { get; set; }

    /// <summary>
    /// For TriggerType.Promotion
    /// </summary>
    public int? PromotionId { get; set; }
    [DisplayName("پویش")]
    public Promotion? Promotion { get; set; }

    /// <summary>
    /// For TriggerType.PurchaseProduct or TriggerType.ConsumeAsset
    /// </summary>
    [OldDbMap("ProductId")]
    public int? AwardId { get; set; }
    [DisplayName("پاداش")]
    [SBVR(SBVRModality.Permitted, "شرط پاداش", "پاداش برای تعریف شرایطی که بر اساس خرید یا استفاده از پاداش فعال می‌شود استفاده می‌شود")]
    public Reward? Award { get; set; }

    /// <summary>
    /// For TriggerType.PurchaseProduct - محصولات سازمان
    /// </summary>
    public int? TenantProductOrServiceId { get; set; }
    [DisplayName("محصول سازمان")]
    [SBVR(SBVRModality.Permitted, "شرط محصول سازمان", "محصول سازمان برای تعریف شرایطی که بر اساس خرید محصولات سازمانی فعال می‌شود استفاده می‌شود")]
    public Product? TenantProductOrService { get; set; }

    /// <summary>
    /// شرط های هم گروه با هم And می شوند
    /// </summary>
    [DisplayName("گروه شرط")]
    public ConditionGroup? ConditionGroup { get; set; }

    [DisplayName("نوع شرط")]
    public ScoringRuleTriggerConditionKind Kind { get; set; }

    [DisplayName("فرمول شرط")]
    [MaxLength(512)]
    public string? Constraint { get; set; }

    [DisplayName("مقایسه شود با")]
    public ScoringRuleTriggerConditionCompareWith? CompareWith { get; set; }

    public int? PointId { get; set; }
    [DisplayName("امتیاز")]
    public Point? Point { get; set; }

    public int? EventTypeParameterId { get; set; }
    [DisplayName("پارامتر رویداد")]
    public EventTypeParameter? EventTypeParameter { get; set; }

    [DisplayName("مقدار")]
    [MaxLength(512)]
    public string? Value { get; set; }
}
