using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;
using Club.Domain.Entities.Rewards;

namespace Club.AdminPanel.Domain.UiDefinitions.Operational;

/// <summary>
/// گزارش‌های عملیاتی برای داشبورد عملیاتی
/// </summary>
public class OperationalReportConfigs
{
    // =====================================================
    // Points & Transactions Reports
    // =====================================================

    /// <summary>
    /// گزارش آمار امتیازات اعطا شده
    /// </summary>
    public partial class PointsIssuedStatsConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst]; }
        
        protected override void Identify()
        {
            DefineConfig("آمار امتیازات اعطا شده", ReportViewType.Chart, Report.ChartType.MetricBox);
        }

        protected override void DefineColumns()
        {
            Sum(nameof(CustomerTransaction.Credit), "مجموع امتیازات اعطا شده");
        }
    }

    /// <summary>
    /// گزارش آمار امتیازات مصرف شده
    /// </summary>
    public partial class PointsRedeemedStatsConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
        
        protected override void Identify()
        {
            DefineConfig("آمار امتیازات مصرف شده", ReportViewType.Chart, Report.ChartType.MetricBox);
        }

        protected override void DefineColumns()
        {
            Sum(nameof(CustomerTransaction.Debit), "مجموع امتیازات مصرف شده");
        }
    }

    /// <summary>
    /// گزارش نسبت امتیازات اعطا شده به مصرف شده
    /// </summary>
    public partial class PointsIssuedVsRedeemedConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
        
        protected override void Identify()
        {
                DefineConfig("امتیازات اعطا شده در مقابل مصرف شده", ReportViewType.Chart, Report.ChartType.Pie);
        }

        protected override void DefineColumns()
        {
            Sum(nameof(CustomerTransaction.Credit), "اعطا شده");
            Sum(nameof(CustomerTransaction.Debit), "مصرف شده");
        }
    }

    /// <summary>
    /// گزارش امتیازات به تفکیک نوع
    /// </summary>
    public partial class PointsByTypeConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
        
        protected override void Identify()
        {
            DefineConfig("امتیازات به تفکیک نوع", ReportViewType.Chart, Report.ChartType.Pie);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(CustomerTransaction.PointId), "نوع امتیاز");
            Sum(nameof(CustomerTransaction.Credit), "مجموع");
        }
    }

    // =====================================================
    // Scoring Rules Reports
    // =====================================================

    /// <summary>
    /// گزارش عملکرد قوانین امتیازدهی
    /// </summary>
    public partial class ScoringRulesPerformanceConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
        
        protected override void Identify()
        {
            DefineConfig("عملکرد قوانین امتیازدهی", ReportViewType.List);
        }

        protected override void DefineColumns()
        {
            DisplayColumn(nameof(ScoringRule.Title), "قانون");
        }
    }

    /// <summary>
    /// گزارش تعداد اجرای قوانین امتیازدهی
    /// </summary>
    public partial class ScoringRuleExecutionsConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
        
        protected override void Identify()
        {
            DefineConfig("تعداد اجرای قوانین", ReportViewType.Chart, Report.ChartType.Bar);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(CustomerTransaction.ScoringRuleId), "قانون");
            Count(null, "تعداد اجرا");
            Sum(nameof(CustomerTransaction.Credit), "مجموع امتیازات");
        }
    }

    // =====================================================
    // Reward Reports
    // =====================================================

    /// <summary>
    /// گزارش هزینه پاداش‌ها
    /// </summary>
    public partial class RewardCostAnalysisConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("تحلیل هزینه پاداش‌ها", ReportViewType.List);
        }

        protected override void DefineColumns()
        {
            DisplayColumn(nameof(Reward.Title), "پاداش");
            DisplayColumn(nameof(Reward.ActualCost), "هزینه واقعی");
            DisplayColumn(nameof(Reward.Value), "ارزش امتیازی");
            DisplayColumn(nameof(Reward.ProfitMargin), "حاشیه سود");
        }
    }

    // =====================================================
    // System Health Reports - Moved to EventLogUiDefinitions
    // =====================================================
    
    // =====================================================
    // Lottery Reports - Moved to LotteryUiDefinitions
    // =====================================================
}
