using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using CustomerTransactionUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Customers.CustomerTransactionUiDefinitions;
using PointUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Points.PointUiDefinitions;
using ClubRuleDefinitions = Club.AdminPanel.Domain.UiDefinitions.ScoringRules.ClubRuleDefinitions;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        // =====================================================
        // 7. داشبورد تراکنش‌ها و امتیازات
        // =====================================================
        public partial class PointsTransactionsDashboard : DashboardConfigDefinition
        {
            protected override string Title => "تراکنش‌ها و امتیازات";
            protected override List<string>? Roles => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for Points & Transactions Dashboard
            // =====================================================

            public partial class TransactionOverviewDiv : DashboardDivDefinition
            {
                public override string Title => "نمای کلی تراکنش‌ها";
                public override long Width => 12;
                public override bool IsRow => true;

                public partial class TransactionsByMonthWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.TransactionsByMonthConfig>
                {
                    public override string Title => "روند تراکنش‌های ماهانه";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 8;
                }

                public partial class TransactionsByTypeWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.TransactionsByTypeConfig>
                {
                    public override string Title => "توزیع تراکنش‌ها به تفکیک نوع";
                    public override long Width => 4;
                }
            }

            public partial class TopPerformersDiv : DashboardDivDefinition
            {
                public override string Title => "مشتریان برتر";
                public override long Width => 6;

                public partial class TopCustomersByTransactionsWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.TopCustomersByTransactionsConfig>
                {
                    public override string Title => "مشتریان با بیشترین تراکنش";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class PointsBalanceDiv : DashboardDivDefinition
            {
                public override string Title => "موجودی امتیازات";
                public override long Width => 6;

                public partial class CustomerPointsBalanceWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.CustomerPointsBalanceConfig>
                {
                    public override string Title => "وضعیت موجودی مشتریان";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class UnvisitedActivityDiv : DashboardDivDefinition
            {
                public override string Title => "تراکنش‌های بازدید نشده";
                public override long Width => 12;

                public partial class UnvisitedTransactionsWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.UnvisitedTransactionsConfig>
                {
                    public override string Title => "امتیازات جدید (بازدید نشده توسط مشتری)";
                    protected override int? MaxRecordCount => 20;
                    public override long Width => 12;
                }
            }

            public partial class TransactionMetricsDiv : DashboardDivDefinition
            {
                public override string Title => "شاخص‌های کلیدی";
                public override long Width => 4;

                public partial class AverageTransactionValueWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.AverageTransactionValueConfig>
                {
                    public override string Title => "میانگین ارزش تراکنش";
                    public override long Width => 12;
                }
            }

            public partial class ScoringRulesAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل قوانین امتیازدهی";
                public override long Width => 8;

                public partial class TransactionsByScoringRuleWidget : DashboardDivWidgetDefinition<CustomerTransactionUiDefinitions, CustomerTransactionUiDefinitions.PublicReport, CustomerTransactionUiDefinitions.PublicReport.TransactionsByScoringRuleConfig>
                {
                    public override string Title => "تراکنش‌ها به تفکیک قانون امتیازدهی";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class PointTypesDiv : DashboardDivDefinition
            {
                public override string Title => "انواع امتیازات";
                public override long Width => 6;

                public partial class PointsByTypeWidget : DashboardDivWidgetDefinition<PointUiDefinitions, PointUiDefinitions.PublicReport, PointUiDefinitions.PublicReport.PointsByTypeConfig>
                {
                    public override string Title => "توزیع امتیازات به تفکیک نوع";
                    public override long Width => 12;
                }
            }

            public partial class AutoVisitPointsDiv : DashboardDivDefinition
            {
                public override string Title => "امتیازات خودکار";
                public override long Width => 6;

                public partial class AutoVisitPointsWidget : DashboardDivWidgetDefinition<PointUiDefinitions, PointUiDefinitions.PublicReport, PointUiDefinitions.PublicReport.AutoVisitPointsConfig>
                {
                    public override string Title => "امتیازات با بازدید خودکار";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class ScoringRulesManagementDiv : DashboardDivDefinition
            {
                public override string Title => "مدیریت قوانین";
                public override long Width => 12;

                public partial class RecentScoringRulesWidget : DashboardDivWidgetDefinition<ClubRuleDefinitions, ClubRuleDefinitions.PublicReport, ClubRuleDefinitions.PublicReport.RecentScoringRulesConfig>
                {
                    public override string Title => "جدیدترین قوانین امتیازدهی";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 6;
                }

                public partial class ScoringRulesByTenantWidget : DashboardDivWidgetDefinition<ClubRuleDefinitions, ClubRuleDefinitions.PublicReport, ClubRuleDefinitions.PublicReport.ScoringRulesByTenantConfig>
                {
                    public override string Title => "قوانین به تفکیک سازمان";
                    public override long Width => 6;
                }
            }
        }
    }
}



