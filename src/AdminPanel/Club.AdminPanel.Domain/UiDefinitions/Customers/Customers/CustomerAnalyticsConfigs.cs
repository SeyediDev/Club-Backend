using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Customer Lifetime Value (CLV) Reports
        // =====================================================

        /// <summary>
        /// گزارش توزیع CLV مشتریان
        /// </summary>
        public partial class ClvDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("توزیع ارزش طول عمر مشتریان", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.CustomerLifetimeValue), "ارزش طول عمر");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش میانگین CLV به تفکیک دسته RFM
        /// </summary>
        public partial class AverageClvByRfmSegmentConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("میانگین CLV به تفکیک دسته RFM", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.RfmSegment), "دسته RFM");
                Average(nameof(Customer.CustomerLifetimeValue), "میانگین CLV");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان با بالاترین CLV
        /// </summary>
        public partial class TopCustomersByClvConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("مشتریان با بالاترین CLV", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Customer.FirstName), "نام");
                DisplayColumn(nameof(Customer.LastName), "نام خانوادگی");
                DisplayColumn(nameof(Customer.MobileNo), "موبایل");
                DisplayColumn(nameof(Customer.CustomerLifetimeValue), "CLV");
                DisplayColumn(nameof(Customer.TotalTransactionValue), "ارزش کل تراکنش‌ها");
                DisplayColumn(nameof(Customer.AverageOrderValue), "میانگین ارزش سفارش");
                
                OrderByDesc(nameof(Customer.CustomerLifetimeValue)); // نزولی - بالاترین CLV
            }
        }

        // =====================================================
        // Customer Retention Reports
        // =====================================================

        /// <summary>
        /// گزارش نرخ حفظ مشتری به تفکیک ماه
        /// </summary>
        public partial class RetentionRateByMonthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Customer.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("نرخ حفظ مشتری ماهانه", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("LastInteractionDateMonth", "ماه");
                Count(null, "تعداد مشتریان فعال");
            }
        }

        /// <summary>
        /// گزارش کوهورت - تحلیل حفظ مشتری
        /// </summary>
        public partial class CustomerCohortAnalysisConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("تحلیل کوهورت مشتریان", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn("CreatedAtMonth", "ماه عضویت");
                DisplayColumn(nameof(Customer.Id), "تعداد مشتریان");
            }
        }

        // =====================================================
        // Churn Analysis Reports
        // =====================================================

        /// <summary>
        /// گزارش مشتریان در معرض خطر ریزش
        /// </summary>
        public partial class CustomersAtRiskConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Customer.ChurnRiskScore)} > 50";
            
            protected override void Identify()
            {
                DefineConfig("مشتریان در معرض خطر ریزش", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Customer.FirstName), "نام");
                DisplayColumn(nameof(Customer.LastName), "نام خانوادگی");
                DisplayColumn(nameof(Customer.MobileNo), "موبایل");
                DisplayColumn(nameof(Customer.ChurnRiskScore), "نمره احتمال ریزش");
                DisplayColumn(nameof(Customer.DaysSinceLastInteraction), "روز از آخرین تعامل");
                DisplayColumn(nameof(Customer.CustomerLifetimeValue), "CLV");
                
                OrderByDesc(nameof(Customer.ChurnRiskScore)); // نزولی - بالاترین خطر
            }
        }

        /// <summary>
        /// گزارش توزیع نمره احتمال ریزش
        /// </summary>
        public partial class ChurnRiskDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("توزیع احتمال ریزش", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.ChurnRiskScore), "محدوده نمره ریزش");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش نرخ ریزش به تفکیک ماه
        /// </summary>
        public partial class ChurnRateByMonthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("نرخ ریزش ماهانه", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("LastInteractionDateMonth", "ماه");
                Count(null, "مشتریان غیرفعال شده");
            }
        }

        // =====================================================
        // Engagement Score Reports
        // =====================================================

        /// <summary>
        /// گزارش توزیع نمره تعامل مشتریان
        /// </summary>
        public partial class EngagementScoreDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("توزیع نمره تعامل", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.EngagementScore), "نمره تعامل");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان با بالاترین تعامل
        /// </summary>
        public partial class HighlyEngagedCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Customer.EngagementScore)} > 70";
            
            protected override void Identify()
            {
                DefineConfig("مشتریان با تعامل بالا", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Customer.FirstName), "نام");
                DisplayColumn(nameof(Customer.LastName), "نام خانوادگی");
                DisplayColumn(nameof(Customer.EngagementScore), "نمره تعامل");
                DisplayColumn(nameof(Customer.TotalInteractions), "تعداد تعاملات");
                DisplayColumn(nameof(Customer.LastInteractionDate), "آخرین تعامل");
                
                OrderByDesc(nameof(Customer.EngagementScore)); // نزولی - بالاترین تعامل
            }
        }

        /// <summary>
        /// گزارش میانگین نمره تعامل به تفکیک دسته RFM
        /// </summary>
        public partial class AverageEngagementByRfmConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("میانگین تعامل به تفکیک RFM", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.RfmSegment), "دسته RFM");
                Average(nameof(Customer.EngagementScore), "میانگین نمره تعامل");
                Count(null, "تعداد");
            }
        }

        // =====================================================
        // NPS & Satisfaction Reports
        // =====================================================

        /// <summary>
        /// گزارش توزیع NPS Score
        /// </summary>
        public partial class NpsDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("توزیع نمره NPS", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.NpsScore), "نمره NPS");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش دسته‌بندی NPS - Promoters, Passives, Detractors
        /// </summary>
        public partial class NpsSegmentationConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("دسته‌بندی NPS", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.NpsScore), "دسته NPS");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش میانگین نمره رضایت
        /// </summary>
        public partial class AverageSatisfactionScoreConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("میانگین نمره رضایت", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Average(nameof(Customer.SatisfactionScore), "میانگین رضایت");
            }
        }

        /// <summary>
        /// گزارش توزیع نمره رضایت
        /// </summary>
        public partial class SatisfactionScoreDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("توزیع نمره رضایت", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.SatisfactionScore), "نمره رضایت");
                Count(null, "تعداد مشتریان");
            }
        }

        // =====================================================
        // Loyalty Score Reports
        // =====================================================

        /// <summary>
        /// گزارش توزیع نمره وفاداری
        /// </summary>
        public partial class LoyaltyScoreDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("توزیع نمره وفاداری", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.LoyaltyScore), "نمره وفاداری");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان وفادار
        /// </summary>
        public partial class LoyalCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Customer.LoyaltyScore)} > 70";
            
            protected override void Identify()
            {
                DefineConfig("مشتریان وفادار", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Customer.FirstName), "نام");
                DisplayColumn(nameof(Customer.LastName), "نام خانوادگی");
                DisplayColumn(nameof(Customer.LoyaltyScore), "نمره وفاداری");
                DisplayColumn(nameof(Customer.CustomerLifetimeValue), "CLV");
                DisplayColumn(nameof(Customer.TotalInteractions), "تعداد تعاملات");
                
                OrderByDesc(nameof(Customer.LoyaltyScore)); // نزولی - بالاترین وفاداری
            }
        }
    }
}
