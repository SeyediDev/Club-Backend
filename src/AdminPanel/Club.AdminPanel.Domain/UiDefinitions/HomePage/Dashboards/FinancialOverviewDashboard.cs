using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using PromotionUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Promotions.PromotionUiDefinitions;
using CustomerUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Customers.Customers.CustomerUiDefinitions;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{

    public partial class HomePageDashboard
    {
        // =====================================================
        // 4. داشبورد نمای مالی
        // =====================================================
        public partial class FinancialOverviewDashboard : DashboardConfigDefinition
        {
            protected override string Title => "نمای مالی";
            protected override List<string>? Roles => [ClubRoles.FinanceManager, Neo.Domain.Constants.Roles.Admin];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for Financial Overview Dashboard
            // =====================================================

            public partial class TotalRevenueDiv : DashboardDivDefinition
            {
                public override string Title => "کل درآمد";
                public override long Width => 12;

                public partial class TotalRevenueWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.TotalRevenueConfig>
                {
                    public override string Title => "کل درآمد";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 12;
                }
            }

            public partial class CustomerProfitabilityDiv : DashboardDivDefinition
            {
                public override string Title => "سودآوری مشتری";
                public override long Width => 6;

                public partial class CustomerProfitabilityWidget : DashboardDivWidgetDefinition<CustomerUiDefinitions, CustomerUiDefinitions.PublicReport, CustomerUiDefinitions.PublicReport.AverageClvByRfmSegmentConfig>
                {
                    public override string Title => "سودآوری به تفکیک RFM";
                    public override long Width => 12;
                }
            }

            public partial class RevenueTrendDiv : DashboardDivDefinition
            {
                public override string Title => "روند درآمد";
                public override long Width => 6;

                public partial class RevenueTrendWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.CampaignPerformanceTrendConfig>
                {
                    public override string Title => "روند عملکرد";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 12;
                }
            }

            public partial class MarketingCostsDiv : DashboardDivDefinition
            {
                public override string Title => "هزینه‌های بازاریابی";
                public override long Width => 6;

                public partial class MarketingCostsWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.CampaignRoiAnalysisConfig>
                {
                    public override string Title => "هزینه‌ها و ROI";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class OverallROIDiv : DashboardDivDefinition
            {
                public override string Title => "بازگشت سرمایه کل";
                public override long Width => 6;

                public partial class OverallRoiWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.OverallRoiConfig>
                {
                    public override string Title => "ROI کلی";
                    protected override int? MaxRecordCount => 1;
                    public override long Width => 12;
                }
            }

            public partial class RevenueForecastDiv : DashboardDivDefinition
            {
                public override string Title => "پیش‌بینی درآمد";
                public override long Width => 12;

                public partial class RevenueForecastWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.CampaignPerformanceTrendConfig>
                {
                    public override string Title => "روند و پیش‌بینی";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 12;
                }
            }
        }
    }
}
