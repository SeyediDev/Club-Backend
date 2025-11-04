using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using CustomerUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Customers.Customers.CustomerUiDefinitions;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        // =====================================================
        // 2. داشبورد تحلیل مشتریان
        // =====================================================
        public partial class CustomerAnalyticsDashboard : DashboardConfigDefinition
        {
            protected override string Title => "تحلیل مشتریان";
            protected override List<string>? Roles => [ClubRoles.MarketingManager, ClubRoles.Analyst];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for Customer Analytics Dashboard
            // =====================================================

            public partial class CLVAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل ارزش طول عمر مشتری (CLV)";
                public override long Width => 6;

                public partial class ClvDistributionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.ClvDistributionConfig>
                {
                    public override string Title => "توزیع CLV";
                    public override long Width => 12;
                }

                public partial class AverageClvByRfmWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.AverageClvByRfmSegmentConfig>
                {
                    public override string Title => "میانگین CLV به تفکیک RFM";
                    public override long Width => 12;
                }
            }

            public partial class CustomerRetentionDiv : DashboardDivDefinition
            {
                public override string Title => "نرخ حفظ مشتری";
                public override long Width => 6;

                public partial class RetentionRateWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.RetentionRateByMonthConfig>
                {
                    public override string Title => "نرخ حفظ ماهانه";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 12;
                }
            }

            public partial class ChurnAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل ریزش مشتری";
                public override long Width => 6;

                public partial class CustomersAtRiskWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.CustomersAtRiskConfig>
                {
                    public override string Title => "مشتریان در معرض خطر";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }

                public partial class ChurnRiskDistributionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.ChurnRiskDistributionConfig>
                {
                    public override string Title => "توزیع احتمال ریزش";
                    public override long Width => 12;
                }
            }

            public partial class EngagementScoreDiv : DashboardDivDefinition
            {
                public override string Title => "امتیاز تعامل مشتری";
                public override long Width => 6;

                public partial class EngagementDistributionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.EngagementScoreDistributionConfig>
                {
                    public override string Title => "توزیع نمره تعامل";
                    public override long Width => 12;
                }

                public partial class HighlyEngagedWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.HighlyEngagedCustomersConfig>
                {
                    public override string Title => "مشتریان با تعامل بالا";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class NPSAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل امتیاز تبلیغ دهان به دهان (NPS)";
                public override long Width => 6;

                public partial class NpsSegmentationWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.NpsSegmentationConfig>
                {
                    public override string Title => "دسته‌بندی NPS";
                    public override long Width => 12;
                }

                public partial class NpsDistributionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.NpsDistributionConfig>
                {
                    public override string Title => "توزیع نمره NPS";
                    public override long Width => 12;
                }
            }

            public partial class CustomerSatisfactionDiv : DashboardDivDefinition
            {
                public override string Title => "رضایت مشتری";
                public override long Width => 6;

                public partial class AverageSatisfactionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.AverageSatisfactionScoreConfig>
                {
                    public override string Title => "میانگین رضایت";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 12;
                }

                public partial class SatisfactionDistributionWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.SatisfactionScoreDistributionConfig>
                {
                    public override string Title => "توزیع نمره رضایت";
                    public override long Width => 12;
                }
            }
        }
    }
}
