namespace Club.Domain.Entities.ScoringRules;

public enum ScoringRuleTriggerConditionKind
{
    [Description("بدون شرط اضافی")]
    WithoutExtraCondition = 0,
    [Description("فرمول شرط")]
    Formula = 1,
    [Description("برابر")]
    EqualTo = 2,
    [Description("نابرابر")]
    NotEqualTo = 3,
    [Description("بزرگتر")]
    GreaterThan = 4,
    [Description("کوچکتر")]
    LessThan = 5,
    [Description("بزرگتر مساوی")]
    GreaterThanOrEqualTo = 6,
    [Description("کوچکتر مساوی")]
    LessThanOrEqualTo = 7
}