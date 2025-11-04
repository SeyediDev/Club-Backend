namespace Club.Bpms.UiDefinitions.ScoringRules;

public class ScoringRuleActionUiDefinitions : SubCRUDDefinition<ScoringRuleAction>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(
            nameof(ScoringRuleAction.ScoringRule),
            nameof(ScoringRuleAction.ActionKind),
            nameof(ScoringRuleAction.NotificationMethod),
            nameof(ScoringRuleAction.Point),
            nameof(ScoringRuleAction.Award),
            nameof(ScoringRuleAction.TenantProductOrService),
            nameof(ScoringRuleAction.CustomerParameter),
            nameof(ScoringRuleAction.CustomerSegment),
            nameof(ScoringRuleAction.ActionOnWho)
            );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(
            nameof(ScoringRuleAction.ScoringRule),
            nameof(ScoringRuleAction.ActionOnWho),
            nameof(ScoringRuleAction.ActionKind),
            nameof(ScoringRuleAction.NotificationMethod),
            nameof(ScoringRuleAction.Point),
            nameof(ScoringRuleAction.Award),
            nameof(ScoringRuleAction.TenantProductOrService),
            nameof(ScoringRuleAction.CustomerParameter),
            nameof(ScoringRuleAction.CustomerSegment),
            nameof(ScoringRuleAction.Order),
            nameof(ScoringRuleAction.AmountMethod),
            nameof(ScoringRuleAction.AmountParameter),
            nameof(ScoringRuleAction.Amount),
            nameof(ScoringRuleAction.AmountFormula),
            nameof(ScoringRuleAction.MessageTemplate)
            );
    }

    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(
            nameof(ScoringRuleAction.ActionKind),
            nameof(ScoringRuleAction.NotificationMethod),
            nameof(ScoringRuleAction.Point),
            nameof(ScoringRuleAction.Award),
            nameof(ScoringRuleAction.TenantProductOrService),
            nameof(ScoringRuleAction.CustomerParameter),
            nameof(ScoringRuleAction.CustomerSegment),
            nameof(ScoringRuleAction.ActionOnWho)
            );
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(
            nameof(ScoringRuleAction.ActionOnWho),
            nameof(ScoringRuleAction.ActionKind),
            nameof(ScoringRuleAction.NotificationMethod),
            nameof(ScoringRuleAction.Point),
            nameof(ScoringRuleAction.Award),
            nameof(ScoringRuleAction.TenantProductOrService),
            nameof(ScoringRuleAction.CustomerParameter),
            nameof(ScoringRuleAction.CustomerSegment),
            nameof(ScoringRuleAction.Order),
            nameof(ScoringRuleAction.AmountMethod),
            nameof(ScoringRuleAction.AmountParameter),
            nameof(ScoringRuleAction.Amount),
            nameof(ScoringRuleAction.AmountFormula),
            nameof(ScoringRuleAction.MessageTemplate)
            );
    }
    
    protected override void UIRules(FormDefinition form)
    {
        form.ShowHide(nameof(ScoringRuleAction.NotificationMethod),
            $"q[{nameof(ScoringRuleAction.NotificationMethod)}]>0",
            nameof(ScoringRuleAction.MessageTemplate));

    }
}