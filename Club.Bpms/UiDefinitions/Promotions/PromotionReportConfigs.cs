using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Promotions;

public partial class PromotionUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Campaign Performance Reports
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

        // =====================================================
        // Campaign Performance Reports (continued)
        // =====================================================

        /// <summary>
        /// گزارش عملکرد کمپین‌ها - نمای کلی
        /// </summary>
        public partial class CampaignPerformanceOverviewConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("عملکرد کلی کمپین‌ها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Promotion.Title), "عنوان پویش");
                DisplayColumn(nameof(Promotion.CampaignStatus), "وضعیت");
                DisplayColumn(nameof(Promotion.TargetAudienceCount), "هدف");
                DisplayColumn(nameof(Promotion.ConversionCount), "تبدیل");
                DisplayColumn(nameof(Promotion.ConversionRate), "نرخ تبدیل (%)");
                DisplayColumn(nameof(Promotion.ReturnOnInvestment), "ROI (%)");
                DisplayColumn(nameof(Promotion.EffectivenessScore), "نمره اثربخشی");
                
                OrderByDesc(nameof(Promotion.EffectivenessScore)); // نزولی - بهترین عملکرد
            }
        }

        /// <summary>
        /// گزارش ROI کمپین‌ها
        /// </summary>
        public partial class CampaignRoiAnalysisConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager, ClubRoles.FinanceManager]; }
            
            protected override void Identify()
            {
                DefineConfig("تحلیل ROI کمپین‌ها", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Sum(nameof(Promotion.CampaignCost), "هزینه");
                Sum(nameof(Promotion.CampaignRevenue), "درآمد");
                Average(nameof(Promotion.ReturnOnInvestment), "ROI (%)");
            }
        }

        /// <summary>
        /// گزارش نرخ تبدیل کمپین‌ها
        /// </summary>
        public partial class ConversionRateAnalysisConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("تحلیل نرخ تبدیل", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Average(nameof(Promotion.ConversionRate), "نرخ تبدیل (%)");
                Sum(nameof(Promotion.TargetAudienceCount), "تعداد هدف");
                Sum(nameof(Promotion.ConversionCount), "تعداد تبدیل");
            }
        }

        /// <summary>
        /// گزارش هزینه جذب مشتری (CAC)
        /// </summary>
        public partial class CustomerAcquisitionCostConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager, ClubRoles.FinanceManager]; }
            
            protected override void Identify()
            {
                DefineConfig("تحلیل هزینه جذب مشتری", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Average(nameof(Promotion.CustomerAcquisitionCost), "CAC");
                Sum(nameof(Promotion.NewCustomersAcquired), "مشتریان جدید");
                Sum(nameof(Promotion.CampaignCost), "هزینه کمپین");
            }
        }

        // =====================================================
        // Message Effectiveness Reports
        // =====================================================

        /// <summary>
        /// گزارش نرخ تحویل پیام‌ها
        /// </summary>
        public partial class MessageDeliveryRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("نرخ تحویل پیام‌ها", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Sum(nameof(Promotion.MessagesSent), "ارسال شده");
                Sum(nameof(Promotion.MessagesDelivered), "تحویل شده");
                Average(nameof(Promotion.DeliveryRate), "نرخ تحویل (%)");
            }
        }

        /// <summary>
        /// گزارش نرخ باز شدن پیام‌ها
        /// </summary>
        public partial class MessageOpenRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("نرخ باز شدن پیام‌ها", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Sum(nameof(Promotion.MessagesDelivered), "تحویل شده");
                Sum(nameof(Promotion.OpenCount), "باز شده");
                Average(nameof(Promotion.OpenRate), "نرخ باز شدن (%)");
            }
        }

        /// <summary>
        /// گزارش نرخ کلیک پیام‌ها
        /// </summary>
        public partial class MessageClickThroughRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("نرخ کلیک پیام‌ها", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Sum(nameof(Promotion.OpenCount), "باز شده");
                Sum(nameof(Promotion.ClickCount), "کلیک شده");
                Average(nameof(Promotion.ClickThroughRate), "نرخ کلیک (%)");
            }
        }

        /// <summary>
        /// گزارش فانل تعامل پیام (Delivery → Open → Click → Conversion)
        /// </summary>
        public partial class MessageEngagementFunnelConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("فانل تعامل پیام", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Sum(nameof(Promotion.MessagesSent), "ارسال");
                Sum(nameof(Promotion.MessagesDelivered), "تحویل");
                Sum(nameof(Promotion.OpenCount), "باز شدن");
                Sum(nameof(Promotion.ClickCount), "کلیک");
                Sum(nameof(Promotion.ConversionCount), "تبدیل");
            }
        }

        // =====================================================
        // Campaign Comparison Reports
        // =====================================================

        /// <summary>
        /// گزارش مقایسه عملکرد کمپین‌ها
        /// </summary>
        public partial class CampaignComparisonConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("مقایسه عملکرد کمپین‌ها", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "پویش");
                Average(nameof(Promotion.ConversionRate), "نرخ تبدیل");
                Average(nameof(Promotion.ReturnOnInvestment), "ROI");
                Average(nameof(Promotion.EffectivenessScore), "نمره اثربخشی");
            }
        }

        /// <summary>
        /// گزارش کمپین‌های فعال
        /// </summary>
        public partial class ActiveCampaignsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            protected override string WhereCondition => $"{nameof(Promotion.CampaignStatus)} == \"Active\"";
            
            protected override void Identify()
            {
                DefineConfig("کمپین‌های فعال", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Promotion.Title), "عنوان");
                DisplayColumn(nameof(Promotion.FromDate), "تاریخ شروع");
                DisplayColumn(nameof(Promotion.ToDate), "تاریخ پایان");
                DisplayColumn(nameof(Promotion.CustomerSegmentId), "جامعه هدف");
                DisplayColumn(nameof(Promotion.TargetAudienceCount), "تعداد هدف");
                DisplayColumn(nameof(Promotion.ConversionCount), "تبدیل‌های فعلی");
                
                OrderByDesc(nameof(Promotion.FromDate)); // نزولی - جدیدترین کمپین‌ها
            }
        }

        /// <summary>
        /// گزارش هزینه هر تبدیل
        /// </summary>
        public partial class CostPerConversionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager, ClubRoles.FinanceManager]; }
            
            protected override void Identify()
            {
                DefineConfig("هزینه هر تبدیل", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Average(nameof(Promotion.CostPerConversion), "هزینه هر تبدیل");
                Sum(nameof(Promotion.ConversionCount), "تعداد تبدیل‌ها");
                Sum(nameof(Promotion.CampaignCost), "هزینه کل");
            }
        }

        /// <summary>
        /// گزارش نمره اثربخشی کمپین‌ها
        /// </summary>
        public partial class CampaignEffectivenessScoreConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("نمره اثربخشی کمپین‌ها", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Title), "عنوان پویش");
                Average(nameof(Promotion.EffectivenessScore), "نمره اثربخشی");
            }
        }

        /// <summary>
        /// گزارش کمپین‌ها به تفکیک دسته‌بندی
        /// </summary>
        public partial class CampaignsByCategoryConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("کمپین‌ها به تفکیک دسته", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Promotion.Category), "دسته‌بندی");
                Count(null, "تعداد کمپین‌ها");
                Average(nameof(Promotion.ConversionRate), "میانگین نرخ تبدیل");
            }
        }

        /// <summary>
        /// گزارش روند عملکرد کمپین در طول زمان
        /// </summary>
        public partial class CampaignPerformanceTrendConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("روند عملکرد کمپین", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("LastMetricsCalculationDateMonth", "ماه");
                Average(nameof(Promotion.ConversionRate), "میانگین نرخ تبدیل");
                Average(nameof(Promotion.ReturnOnInvestment), "میانگین ROI");
            }
        }
    }
}
