using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using CustomerUiDefinitions = Club.Bpms.UiDefinitions.Customers.Customers.CustomerUiDefinitions;
using CustomerSegmentUiDefinitions = Club.Bpms.UiDefinitions.Customers.CustomerSegments.CustomerSegmentUiDefinitions;
using PromotionUiDefinitions = Club.Bpms.UiDefinitions.Promotions.PromotionUiDefinitions;
// using SurveyUiDefinitions = Club.Bpms.UiDefinitions.Surveys.SurveyUiDefinitions;
// using FeedbackUiDefinitions = Club.Bpms.UiDefinitions.Feedback.CustomerFeedbackUiDefinitions;

namespace Club.Bpms.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{

    public partial class HomePageDashboard
    {
        // =====================================================
        // 1. داشبورد نمای کلی کسب‌وکار
        // =====================================================
        public partial class MainOverviewDashboard : DashboardConfigDefinition
        {
            protected override string Title => "نمای کلی کسب‌وکار";
            protected override List<string>? Roles => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager];
            protected override bool IsDefault => true;

            // =====================================================
            // Div Definitions for Main Overview Dashboard
            // =====================================================

            public partial class KPISectionDiv : DashboardDivDefinition
            {
                public override string Title => "شاخص‌های عملکرد (KPI)";
                public override long Width => 12;
                public override bool IsRow => true;

                // KPI Widgets
                public partial class CustomerCountWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.CustomerCountConfig>
                {
                    public override string Title => "تعداد کل مشتریان";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }

                public partial class ActiveCustomersWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.ActiveCustomersConfig>
                {
                    public override string Title => "مشتریان فعال";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }

                public partial class NewCustomersWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.NewCustomersConfig>
                {
                    public override string Title => "مشتریان جدید";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }

                // Survey widget - temporarily disabled
                // public partial class TotalSurveysWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.ActiveSurveysConfig>
                // {
                //     public override string Title => "نظرسنجی‌های فعال";
                //     protected override int? MaxRecordCount => 1;
                //     public override long Width => 3;
                // }
            }

            public partial class FeedbackOverviewDiv : DashboardDivDefinition
            {
                public override string Title => "بازخورد مشتریان";
                public override long Width => 12;
                public override bool IsRow => true;

                // Feedback widgets - temporarily disabled
                // public partial class NewFeedbacksWidget : DashboardDivWidgetDefinition<FeedbackUiDefinitions, FeedbackUiDefinitions.PublicReport, FeedbackUiDefinitions.PublicReport.NewFeedbacksConfig>
                // {
                //     public override string Title => "بازخوردهای جدید";
                //     protected override int? MaxRecordCount => 1;
                //     public override long Width => 4;
                // }
                //
                // public partial class UrgentFeedbacksWidget : DashboardDivWidgetDefinition<FeedbackUiDefinitions, FeedbackUiDefinitions.PublicReport, FeedbackUiDefinitions.PublicReport.UrgentFeedbacksConfig>
                // {
                //     public override string Title => "فوری";
                //     protected override int? MaxRecordCount => 1;
                //     public override long Width => 4;
                // }
            }
            
            public partial class RFMAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل RFM";
                public override long Width => 8;

                public partial class RfmSegmentDistributionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.RfmSegmentDistributionConfig>
                {
                    public override string Title => "توزیع جوامع RFM";
                    public override long Width => 12;
                }
            }

            public partial class CustomerGrowthDiv : DashboardDivDefinition
            {
                public override string Title => "رشد مشتریان";
                public override long Width => 4;

                public partial class CustomerGrowthByMonthWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.CustomerGrowthByMonthConfig>
                {
                    public override string Title => "رشد ماهانه";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 12;
                }
            }

            public partial class SegmentDistributionDiv : DashboardDivDefinition
            {
                public override string Title => "توزیع جامعه مشتریان";
                public override long Width => 6;

                public partial class SegmentDistributionWidget : DashboardDivWidgetDefinition<CustomerSegmentUiDefinitions, CustomerSegmentUiDefinitions.PublicReport, CustomerSegmentUiDefinitions.PublicReport.SegmentDistributionConfig>
                {
                    public override string Title => "توزیع جوامع";
                    public override long Width => 12;
                }
            }

            public partial class CampaignPerformanceDiv : DashboardDivDefinition
            {
                public override string Title => "عملکرد کمپین‌ها";
                public override long Width => 4;

                public partial class TopCampaignsWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.CampaignPerformanceOverviewConfig>
                {
                    public override string Title => "کمپین‌های برتر";
                    protected override int? MaxRecordCount => 5;
                    public override long Width => 12;
                }
            }

            public partial class SurveyEngagementDiv : DashboardDivDefinition
            {
                public override string Title => "تعامل با نظرسنجی‌ها";
                public override long Width => 4;

                // Survey widget - temporarily disabled
                // public partial class TopSurveysWidget : DashboardDivWidgetDefinition<SurveyUiDefinitions, SurveyUiDefinitions.PublicReport, SurveyUiDefinitions.PublicReport.TopSurveysConfig>
                // {
                //     public override string Title => "نظرسنجی‌های محبوب";
                //     protected override int? MaxRecordCount => 5;
                //     public override long Width => 12;
                // }
            }

            public partial class KeyMetricsDiv : DashboardDivDefinition
            {
                public override string Title => "شاخص‌های کلیدی";
                public override long Width => 12;
                public override bool IsRow => true;

                public partial class TotalRevenueWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.TotalRevenueConfig>
                {
                    public override string Title => "درآمد کل";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }

                public partial class OverallRoiWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.OverallRoiConfig>
                {
                    public override string Title => "ROI کلی";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 3;
                }
            }
        }
    }
}
