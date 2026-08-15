using Club.Domain.Entities.Promotions.Surveys.Data;

namespace Club.AdminPanel.Domain.UiDefinitions.Surveys;

public class SurveyParticipationUiDefinitions : CRUDDefinition<SurveyParticipation>
{
    private static readonly List<string> DefaultRoles =
    [
        Neo.Domain.Constants.Roles.Admin,
        ClubRoles.Manager,
        ClubRoles.MarketingManager,
        ClubRoles.Analyst
    ];

    public override List<string>? Roles => DefaultRoles;

    protected override void IndexFormViewModel()
    {
        AddColumns(
            nameof(SurveyParticipation.Survey),
            nameof(SurveyParticipation.CustomerTenant),
            nameof(SurveyParticipation.SelectedItem),
            nameof(SurveyParticipation.ParticipationDate),
            nameof(SurveyParticipation.IsCorrect),
            nameof(SurveyParticipation.PointsEarned),
            nameof(SurveyParticipation.Comment)
        );
    }

    protected override void CUDFormsViewModel()
    {
        AddFields(
            nameof(SurveyParticipation.Survey),
            nameof(SurveyParticipation.CustomerTenant),
            nameof(SurveyParticipation.SelectedItem),
            nameof(SurveyParticipation.Comment)
        );
    }
}
