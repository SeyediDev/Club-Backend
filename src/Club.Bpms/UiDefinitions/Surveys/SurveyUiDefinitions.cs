using Club.Domain.Entities.Surveys;

namespace Club.Bpms.UiDefinitions.Surveys;

public partial class SurveyUiDefinitions : CRUDDefinition<Survey>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(
            nameof(Survey.Tenant),
            nameof(Survey.Title),
            nameof(Survey.SurveyType),
            nameof(Survey.IsActive),
            nameof(Survey.StartDate),
            nameof(Survey.EndDate),
            nameof(Survey.TotalParticipants),
            nameof(Survey.ParticipationPoints),
            nameof(Survey.CorrectAnswerPoints)
        );
    }

    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(
            nameof(Survey.Tenant),
            nameof(Survey.Title),
            nameof(Survey.Description),
            nameof(Survey.SurveyType),
            nameof(Survey.Product),
            nameof(Survey.IsActive),
            nameof(Survey.StartDate),
            nameof(Survey.EndDate),
            nameof(Survey.AllowMultipleSelection),
            nameof(Survey.ShowResults),
            nameof(Survey.ParticipationPoints),
            nameof(Survey.CorrectAnswerPoints)
        );
    }

    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(SurveyItem), nameof(SurveyItem.Survey), "Sub",
            "گزینه‌های نظرسنجی", null, false, eControlTypeId.MultiTab);
    }
}
