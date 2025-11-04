using Club.Domain.Entities.Rewards;
using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Awards;

public partial class AwardUiDefinitions : CRUDDefinition<Reward>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Reward.Title),
                        nameof(Reward.Category),
                        nameof(Reward.Merchant),
                        nameof(Reward.Value),
                        nameof(Reward.Quantity),
                        nameof(Reward.TotalSales),
                        nameof(Reward.PopularityScore),
                        nameof(Reward.StockStatus),
                        nameof(Reward.Tenant),
                        nameof(Reward.CustomerSegment)
                        );
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Reward.Title),
                       nameof(Reward.Category),
                       nameof(Reward.Merchant),
                       nameof(Reward.Tenant),
                       nameof(Reward.CustomerSegment),
                       nameof(Reward.Value),
                       nameof(Reward.PointLevel),
                       nameof(Reward.ControlAsset),
                       nameof(Reward.Quantity),
                       nameof(Reward.SerialFormat),
                       nameof(Reward.Visible),
                       nameof(Reward.OrderId),
                       nameof(Reward.LowStockThreshold),
                       nameof(Reward.ActualCost)
                       );
        // Add Picture field as File control (not ComboBox)
        form.AddField(nameof(Reward.Picture), eControlTypeId.File);
    }
    
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(RewardCost), nameof(RewardCost.Reward), "Sub",
            "هزینه ها", null, true, eControlTypeId.MultiTab);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Reward Analytics Reports
        // =====================================================

        /// <summary>
        /// گزارش پاداش‌های محبوب
        /// </summary>
        public partial class PopularRewardsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("پاداش‌های محبوب", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Reward.Title), "پاداش");
                Sum(nameof(Reward.TotalSales), "تعداد فروش");
                Average(nameof(Reward.PopularityScore), "نمره محبوبیت");
                
                OrderByDesc(nameof(Reward.TotalSales)); // نزولی - پرفروش‌ترین
            }
        }

        /// <summary>
        /// گزارش پاداش‌ها به تفکیک دسته
        /// </summary>
        public partial class RewardsByCategoryConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("پاداش‌ها به تفکیک دسته", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Reward.CategoryId), "دسته");
                Count(null, "تعداد پاداش‌ها");
                Sum(nameof(Reward.TotalSales), "مجموع فروش");
            }
        }

        /// <summary>
        /// گزارش نرخ تبدیل پاداش‌ها
        /// </summary>
        public partial class RewardConversionRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("نرخ تبدیل پاداش‌ها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Reward.Title), "پاداش");
                DisplayColumn(nameof(Reward.TotalViews), "بازدید");
                DisplayColumn(nameof(Reward.TotalSales), "فروش");
                DisplayColumn(nameof(Reward.ConversionRate), "نرخ تبدیل (%)");
                DisplayColumn(nameof(Reward.PopularityScore), "محبوبیت");
                
                OrderByDesc(nameof(Reward.ConversionRate)); // نزولی - بالاترین تبدیل
            }
        }

        /// <summary>
        /// گزارش سودآوری پاداش‌ها
        /// </summary>
        public partial class RewardProfitabilityConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.FinanceManager]; }
            
            protected override void Identify()
            {
                DefineConfig("سودآوری پاداش‌ها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Reward.Title), "پاداش");
                DisplayColumn(nameof(Reward.Value), "ارزش امتیازی");
                DisplayColumn(nameof(Reward.ActualCost), "هزینه واقعی");
                DisplayColumn(nameof(Reward.ProfitMargin), "حاشیه سود (%)");
                DisplayColumn(nameof(Reward.TotalSales), "تعداد فروش");
                
                OrderByDesc(nameof(Reward.ProfitMargin)); // نزولی - بیشترین سود
            }
        }

        /// <summary>
        /// گزارش وضعیت موجودی پاداش‌ها
        /// </summary>
        public partial class RewardStockStatusConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("وضعیت موجودی پاداش‌ها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Reward.Title), "پاداش");
                DisplayColumn(nameof(Reward.Quantity), "موجودی");
                DisplayColumn(nameof(Reward.LowStockThreshold), "آستانه کمبود");
                DisplayColumn(nameof(Reward.StockStatus), "وضعیت");
                
                OrderBy(nameof(Reward.Quantity)); // صعودی - کم‌ترین موجودی
            }
        }

        /// <summary>
        /// گزارش رضایت از پاداش‌ها
        /// </summary>
        public partial class RewardSatisfactionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("رضایت از پاداش‌ها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Reward.Title), "پاداش");
                DisplayColumn(nameof(Reward.AverageRating), "میانگین امتیاز");
                DisplayColumn(nameof(Reward.ReviewCount), "تعداد نظرات");
                DisplayColumn(nameof(Reward.TotalSales), "فروش");
                
                OrderByDesc(nameof(Reward.AverageRating)); // نزولی - بهترین امتیاز
            }
        }

        /// <summary>
        /// گزارش پاداش‌های به‌روز رسانی نشده
        /// </summary>
        public partial class OutdatedRewardsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Reward.LastPurchaseDate)} < DateTime.Now.AddMonths(-3)";
            
            protected override void Identify()
            {
                DefineConfig("پاداش‌های قدیمی", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Reward.Title), "پاداش");
                DisplayColumn(nameof(Reward.LastPurchaseDate), "آخرین خرید");
                DisplayColumn(nameof(Reward.TotalSales), "کل فروش");
                DisplayColumn(nameof(Reward.Quantity), "موجودی");
                
                OrderBy(nameof(Reward.LastPurchaseDate)); // صعودی - قدیمی‌ترین
            }
        }
    }
}
