using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using SurveyUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Surveys.SurveyUiDefinitions;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        public partial class SurveyAnalyticsDashboard : DashboardConfigDefinition
        {
            protected override string Title => "تحلیل نظرسنجی‌ها";

            // Row 1: Overview Metrics
            public partial class OverviewDiv : DashboardDivDefinition
            {
                public override string Title => "خلاصه کلی";
                public override long Width => 12;
                public override bool IsRow => true;

                public partial class ActiveSurveysWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.ActiveSurveysConfig>
                {
                    public override string Title => "نظرسنجی‌های فعال";
                    protected override int? MaxRecordCount => 5;
                    public override long Width => 6;
                }

                public partial class AverageParticipationWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.AverageParticipationConfig>
                {
                    public override string Title => "میانگین مشارکت";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }

                public partial class TotalSurveysWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.TopSurveysConfig>
                {
                    public override string Title => "مجموع نظرسنجی‌ها";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }
            }

            // Row 2: Charts
            public partial class ChartsDiv : DashboardDivDefinition
            {
                public override string Title => "نمودارها";
                public override long Width => 12;
                public override bool IsRow => true;

                public partial class SurveyTypeDistWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.SurveyTypeDistributionConfig>
                {
                    public override string Title => "توزیع بر اساس نوع";
                    public override long Width => 6;
                }

                public partial class ParticipationTrendWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.SurveyParticipationTrendConfig>
                {
                    public override string Title => "روند مشارکت";
                    public override long Width => 6;
                }
            }

            // Row 3: Details
            public partial class DetailsDiv : DashboardDivDefinition
            {
                public override string Title => "نظرسنجی‌های محبوب";
                public override long Width => 12;

                public partial class TopSurveysWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.TopSurveysConfig>
                {
                    public override string Title => "نظرسنجی‌های محبوب";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }
        }
    }
}

