using Club.Domain.Entities.Surveys;

namespace Club.AdminPanel.Domain.UiDefinitions.Surveys;

public class SurveyParticipationUiDefinitions : CRUDDefinition<SurveyParticipation>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(
            nameof(SurveyParticipation.Survey),
            nameof(SurveyParticipation.Customer),
            nameof(SurveyParticipation.SelectedItem),
            nameof(SurveyParticipation.ParticipationDate),
            nameof(SurveyParticipation.IsCorrect),
            nameof(SurveyParticipation.PointsEarned),
            nameof(SurveyParticipation.Comment)
        );
    }

    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(
            nameof(SurveyParticipation.Survey),
            nameof(SurveyParticipation.Customer),
            nameof(SurveyParticipation.SelectedItem),
            nameof(SurveyParticipation.Comment)
        );
    }
}
