namespace Club.Domain.Entities.ScoringRules;

public enum ScoringRuleActionKind
{
    [Description("افزایش امتیاز")]
    CreditPoint=1,
    [Description("کاهش امتیاز")]
    DebitPoint=2,
    [Description("مقداردهی امتیاز")]
    SetPointBalance=3,

    [Description("مقداردهی پارامتر مشتری")]
    SetCustomerParameterValue = 11,
    [Description("عضویت در جامعه مشتریان")]
    JoinInCustomerSegment = 12,
    [Description("ثبت معرف")]
    ReferrerRegistration = 13,

    [Description("اعطای رایگان محصول به مشتری")]
    GrantProduct = 21,
    
    [Description("فقط اطلاع رسانی")]
    None = 101,
}