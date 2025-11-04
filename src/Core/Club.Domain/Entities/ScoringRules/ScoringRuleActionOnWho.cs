namespace Club.Domain.Entities.ScoringRules;

/// <summary>
/// مشخص می‌کند که عملیات قانون بر روی چه کسی اعمال می‌شود
/// </summary>
public enum ScoringRuleActionOnWho
{
    [Description("مشتری اصلی")]
    Customer = 1,
    
    [Description("معرف")]
    Referrer = 2,
    
    [Description("مشتری و معرف")]
    Both = 3
}