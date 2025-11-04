namespace Club.Bpms.UiDefinitions.ScoringRules;

public class ScoringRuleTriggerConditionUiDefinitions : SubCRUDDefinition<ScoringRuleTriggerCondition>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(ScoringRuleTriggerCondition.ScoringRule),
            nameof(ScoringRuleTriggerCondition.Title),
            nameof(ScoringRuleTriggerCondition.TriggerType),
            nameof(ScoringRuleTriggerCondition.EventChannel),
            nameof(ScoringRuleTriggerCondition.EventType),
            nameof(ScoringRuleTriggerCondition.PointLevel),
            nameof(ScoringRuleTriggerCondition.Promotion),
            nameof(ScoringRuleTriggerCondition.Award),
            nameof(ScoringRuleTriggerCondition.TenantProductOrService)
            );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(ScoringRuleTriggerCondition.ScoringRule),
            nameof(ScoringRuleTriggerCondition.Title),
            nameof(ScoringRuleTriggerCondition.TriggerType),
            nameof(ScoringRuleTriggerCondition.EventChannel),
            nameof(ScoringRuleTriggerCondition.EventType),
            nameof(ScoringRuleTriggerCondition.PointLevel),
            nameof(ScoringRuleTriggerCondition.Promotion),
            nameof(ScoringRuleTriggerCondition.Award),
            nameof(ScoringRuleTriggerCondition.TenantProductOrService),
            nameof(ScoringRuleTriggerCondition.ConditionGroup),
            nameof(ScoringRuleTriggerCondition.Kind),
            nameof(ScoringRuleTriggerCondition.Constraint),
            nameof(ScoringRuleTriggerCondition.CompareWith),
            nameof(ScoringRuleTriggerCondition.Point),
            nameof(ScoringRuleTriggerCondition.EventTypeParameter),
            nameof(ScoringRuleTriggerCondition.Value)
            );
    }

    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(ScoringRuleTriggerCondition.Title),
            nameof(ScoringRuleTriggerCondition.TriggerType),
            nameof(ScoringRuleTriggerCondition.EventChannel),
            nameof(ScoringRuleTriggerCondition.EventType),
            nameof(ScoringRuleTriggerCondition.PointLevel),
            nameof(ScoringRuleTriggerCondition.Promotion),
            nameof(ScoringRuleTriggerCondition.Award),
            nameof(ScoringRuleTriggerCondition.TenantProductOrService)
            );
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(ScoringRuleTriggerCondition.Title),
            nameof(ScoringRuleTriggerCondition.TriggerType),
            nameof(ScoringRuleTriggerCondition.EventChannel),
            nameof(ScoringRuleTriggerCondition.EventType),
            nameof(ScoringRuleTriggerCondition.PointLevel),
            nameof(ScoringRuleTriggerCondition.Promotion),
            nameof(ScoringRuleTriggerCondition.Award),
            nameof(ScoringRuleTriggerCondition.TenantProductOrService),
            nameof(ScoringRuleTriggerCondition.ConditionGroup),
            nameof(ScoringRuleTriggerCondition.Kind),
            nameof(ScoringRuleTriggerCondition.Constraint),
            nameof(ScoringRuleTriggerCondition.CompareWith),
            nameof(ScoringRuleTriggerCondition.Point),
            nameof(ScoringRuleTriggerCondition.EventTypeParameter),
            nameof(ScoringRuleTriggerCondition.Value)
            );
    }
}
