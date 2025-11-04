using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using CustomerTransactionUiDefinitions = Club.Bpms.UiDefinitions.Customers.CustomerTransactionUiDefinitions;
using EventLogUiDefinitions = Club.Bpms.UiDefinitions.Events.EventLogUiDefinitions;
using PointUiDefinitions = Club.Bpms.UiDefinitions.Points.PointUiDefinitions;
using ClubRuleDefinitions = Club.Bpms.UiDefinitions.ScoringRules.ClubRuleDefinitions;

namespace Club.Bpms.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        // =====================================================
        // 5. داشبورد شاخص‌های عملیاتی
        // =====================================================
        public partial class OperationalMetricsDashboard : DashboardConfigDefinition
        {
            protected override string Title => "شاخص‌های عملیاتی";
            protected override List<string>? Roles => [ClubRoles.Analyst, Neo.Domain.Constants.Roles.Admin];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for Operational Metrics Dashboard
            // =====================================================

            public partial class TransactionStatsDiv : DashboardDivDefinition
            {
                public override string Title => "آمار تراکنش‌ها";
                public override long Width => 12;

                public partial class TransactionsByMonthWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.TransactionsByMonthConfig>
                {
                    public override string Title => "تراکنش‌های ماهانه";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 12;
                }
            }

            public partial class SystemEventsDiv : DashboardDivDefinition
            {
                public override string Title => "رویدادهای سیستم";
                public override long Width => 6;

                public partial class EventLogByEventTypeWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByEventTypeConfig>
                {
                    public override string Title => "رویدادها به تفکیک نوع";
                    public override long Width => 12;
                }

                public partial class RecentEventsWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.RecentEventsConfig>
                {
                    public override string Title => "آخرین رویدادها";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class ScoringRulesDiv : DashboardDivDefinition
            {
                public override string Title => "قوانین امتیازدهی";
                public override long Width => 6;

                public partial class ActiveScoringRulesWidget : DashboardDivWidgetDefinition<ClubRuleDefinitions, ClubRuleDefinitions.PublicReport, ClubRuleDefinitions.PublicReport.ActiveScoringRulesConfig>
                {
                    public override string Title => "قوانین فعال";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }

                public partial class ScoringRulesByTenantWidget : DashboardDivWidgetDefinition<ClubRuleDefinitions, ClubRuleDefinitions.PublicReport, ClubRuleDefinitions.PublicReport.ScoringRulesByTenantConfig>
                {
                    public override string Title => "قوانین به تفکیک سازمان";
                    public override long Width => 12;
                }
            }

            public partial class PointsManagementDiv : DashboardDivDefinition
            {
                public override string Title => "مدیریت امتیازات";
                public override long Width => 6;

                public partial class PointsByTypeWidget : DashboardDivWidgetDefinition<PointUiDefinitions, PointUiDefinitions.PublicReport, PointUiDefinitions.PublicReport.PointsByTypeConfig>
                {
                    public override string Title => "امتیازات به تفکیک نوع";
                    public override long Width => 12;
                }

                public partial class VisiblePointsWidget : DashboardDivWidgetDefinition<PointUiDefinitions, PointUiDefinitions.PublicReport, PointUiDefinitions.PublicReport.VisiblePointsConfig>
                {
                    public override string Title => "امتیازات قابل مشاهده";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class ProductStatsDiv : DashboardDivDefinition
            {
                public override string Title => "آمار محصولات";
                public override long Width => 6;

                public partial class PopularProductsWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByProductConfig>
                {
                    public override string Title => "محصولات پرطرفدار";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class MarketAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل بازار";
                public override long Width => 6;

                public partial class SystemActivityWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.SystemActivityDailyConfig>
                {
                    public override string Title => "فعالیت روزانه سیستم";
                    protected override int? MaxRecordCount => 30;
                    public override long Width => 12;
                }
            }

            public partial class ProductMarketFitDiv : DashboardDivDefinition
            {
                public override string Title => "تناسب محصول-بازار";
                public override long Width => 12;

                public partial class ProductEventsWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByProductConfig>
                {
                    public override string Title => "تحلیل محصولات";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }
        }
    }
}
