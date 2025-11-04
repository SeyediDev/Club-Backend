namespace Club.Domain.Entities.ScoringRules;

public enum ScoringRuleActionAmountMethod
{
    [Description("مقدار ثابت")]
    FixAmount,
    [Description("از یک پارامتر")]
    FromParameter,
    [Description("محاسبه فرمول")]
    FromFormula,
}