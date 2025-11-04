using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Financial;

/// <summary>
/// گزارش‌های مالی برای داشبورد مالی
/// </summary>
public class FinancialReportConfigs
{
    // =====================================================
    // Revenue Reports
    // =====================================================

    /// <summary>
    /// گزارش کل درآمد
    /// </summary>
    public partial class TotalRevenueConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("کل درآمد", ReportViewType.Chart, Report.ChartType.MetricBox);
        }

        protected override void DefineColumns()
        {
            Sum(nameof(Promotion.CampaignRevenue), "کل درآمد");
        }
    }

    /// <summary>
    /// گزارش روند درآمد ماهانه
    /// </summary>
    public partial class MonthlyRevenueTrendConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("روند درآمد ماهانه", ReportViewType.Chart, Report.ChartType.Line);
        }

        protected override void DefineColumns()
        {
            GroupBy("FromDateMonth", "ماه");
            Sum(nameof(Promotion.CampaignRevenue), "درآمد");
            Sum(nameof(Promotion.CampaignCost), "هزینه");
        }
    }

    /// <summary>
    /// گزارش درآمد به تفکیک دسته کمپین
    /// </summary>
    public partial class RevenueByCampaignCategoryConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager, ClubRoles.MarketingManager]; }
        
        protected override void Identify()
        {
            DefineConfig("درآمد به تفکیک دسته کمپین", ReportViewType.Chart, Report.ChartType.Pie);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(Promotion.Category), "دسته کمپین");
            Sum(nameof(Promotion.CampaignRevenue), "کل درآمد");
        }
    }

    // =====================================================
    // Cost Reports
    // =====================================================

    /// <summary>
    /// گزارش کل هزینه‌های بازاریابی
    /// </summary>
    public partial class TotalMarketingCostsConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("کل هزینه‌های بازاریابی", ReportViewType.Chart, Report.ChartType.MetricBox);
        }

        protected override void DefineColumns()
        {
            Sum(nameof(Promotion.CampaignCost), "کل هزینه");
        }
    }

    /// <summary>
    /// گزارش هزینه‌های بازاریابی ماهانه
    /// </summary>
    public partial class MonthlyMarketingCostsConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("هزینه‌های بازاریابی ماهانه", ReportViewType.Chart, Report.ChartType.Column);
        }

        protected override void DefineColumns()
        {
            GroupBy("FromDateMonth", "ماه");
            Sum(nameof(Promotion.CampaignCost), "هزینه");
            Count(null, "تعداد کمپین‌ها");
        }
    }

    /// <summary>
    /// گزارش هزینه به تفکیک دسته کمپین
    /// </summary>
    public partial class CostByCampaignCategoryConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("هزینه به تفکیک دسته", ReportViewType.Chart, Report.ChartType.Pie);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(Promotion.Category), "دسته کمپین");
            Sum(nameof(Promotion.CampaignCost), "کل هزینه");
        }
    }

    // =====================================================
    // Profitability Reports
    // =====================================================

    /// <summary>
    /// گزارش سودآوری کلی
    /// </summary>
    public partial class OverallProfitabilityConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("سودآوری کلی", ReportViewType.Chart, Report.ChartType.MetricBox);
        }

        protected override void DefineColumns()
        {
            Sum(nameof(Promotion.CampaignRevenue), "کل درآمد");
            Sum(nameof(Promotion.CampaignCost), "کل هزینه");
        }
    }

    /// <summary>
    /// گزارش سودآوری ماهانه
    /// </summary>
    public partial class MonthlyProfitabilityConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("سودآوری ماهانه", ReportViewType.Chart, Report.ChartType.Line);
        }

        protected override void DefineColumns()
        {
            GroupBy("FromDateMonth", "ماه");
            Sum(nameof(Promotion.CampaignRevenue), "درآمد");
            Sum(nameof(Promotion.CampaignCost), "هزینه");
        }
    }

    /// <summary>
    /// گزارش سودآوری مشتریان (بر اساس CLV)
    /// </summary>
    public partial class CustomerProfitabilityConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("سودآوری مشتریان", ReportViewType.Chart, Report.ChartType.Bar);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(Customer.RfmSegment), "دسته RFM");
            Average(nameof(Customer.CustomerLifetimeValue), "میانگین CLV");
            Count(null, "تعداد مشتریان");
        }
    }

    /// <summary>
    /// گزارش سودآوری جوامع مشتریان
    /// </summary>
    public partial class SegmentProfitabilityConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("سودآوری جوامع", ReportViewType.Chart, Report.ChartType.Bar);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(CustomerSegment.Title), "جامعه مشتریان");
            Sum(nameof(CustomerSegment.ActualSize), "تعداد اعضا");
        }
    }

    // =====================================================
    // ROI Reports
    // =====================================================

    /// <summary>
    /// گزارش ROI کلی
    /// </summary>
    public partial class OverallRoiConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("ROI کلی", ReportViewType.Chart, Report.ChartType.MetricBox);
        }

        protected override void DefineColumns()
        {
            Average(nameof(Promotion.ReturnOnInvestment), "میانگین ROI");
        }
    }

    /// <summary>
    /// گزارش ROI به تفکیک ماه
    /// </summary>
    public partial class MonthlyRoiConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("ROI ماهانه", ReportViewType.Chart, Report.ChartType.Line);
        }

        protected override void DefineColumns()
        {
            GroupBy("FromDateMonth", "ماه");
            Average(nameof(Promotion.ReturnOnInvestment), "میانگین ROI");
        }
    }

    /// <summary>
    /// گزارش مقایسه ROI کمپین‌ها
    /// </summary>
    public partial class CampaignRoiComparisonConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager, ClubRoles.MarketingManager]; }
        
        protected override void Identify()
        {
            DefineConfig("مقایسه ROI کمپین‌ها", ReportViewType.GroupByList);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(Promotion.Title), "کمپین");
            Average(nameof(Promotion.ReturnOnInvestment), "ROI (%)");
            Sum(nameof(Promotion.CampaignRevenue), "درآمد");
            Sum(nameof(Promotion.CampaignCost), "هزینه");
        }
    }

    // =====================================================
    // Forecast Reports
    // =====================================================

    /// <summary>
    /// گزارش پیش‌بینی درآمد
    /// </summary>
    public partial class RevenueForecastConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager, ClubRoles.Analyst]; }
        
        protected override void Identify()
        {
            DefineConfig("پیش‌بینی درآمد", ReportViewType.Chart, Report.ChartType.Line);
        }

        protected override void DefineColumns()
        {
            GroupBy("FromDateMonth", "ماه");
            Sum(nameof(Promotion.CampaignRevenue), "درآمد واقعی");
        }
    }

    /// <summary>
    /// گزارش بودجه در مقابل واقعی
    /// </summary>
    public partial class BudgetVsActualConfig : ReportConfigDefinition
    {
        protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
        
        protected override void Identify()
        {
            DefineConfig("بودجه در مقابل واقعی", ReportViewType.GroupByList);
        }

        protected override void DefineColumns()
        {
            GroupBy(nameof(Promotion.Title), "کمپین");
            Sum(nameof(Promotion.CampaignCost), "هزینه واقعی");
        }
    }
}
