using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // RFM Analysis Reports
        // =====================================================

        /// <summary>
        /// گزارش تحلیل RFM - توزیع مشتریان بر اساس دسته‌های RFM
        /// </summary>
        public partial class RfmSegmentDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst]; }
            protected override void Identify()
            {
                DefineConfig("توزیع جوامع RFM", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.RfmSegment), "دسته RFM");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش نمودار پراکندگی RFM - Recency vs Frequency
        /// </summary>
        public partial class RfmScatterRecencyFrequencyConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override void Identify()
            {
                DefineConfig("نمودار پراکندگی RFM (تازگی-تکرار)", ReportViewType.Chart, Report.ChartType.Scatter);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.RecencyScore), "نمره تازگی");
                GroupBy(nameof(Customer.FrequencyScore), "نمره تکرار");
                Average(nameof(Customer.MonetaryScore), "میانگین نمره ارزش");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش میانگین نمرات RFM به تفکیک دسته
        /// </summary>
        public partial class RfmScoresBySegmentConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("میانگین نمرات RFM", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.RfmSegment), "دسته RFM");
                Average(nameof(Customer.RecencyScore), "میانگین تازگی");
                Average(nameof(Customer.FrequencyScore), "میانگین تکرار");
                Average(nameof(Customer.MonetaryScore), "میانگین ارزش");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان به تفکیک نمره Recency
        /// </summary>
        public partial class CustomersByRecencyScoreConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override void Identify()
            {
                DefineConfig("توزیع نمره تازگی", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.RecencyScore), "نمره تازگی");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان به تفکیک نمره Frequency
        /// </summary>
        public partial class CustomersByFrequencyScoreConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override void Identify()
            {
                DefineConfig("توزیع نمره تکرار", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.FrequencyScore), "نمره تکرار");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان به تفکیک نمره Monetary
        /// </summary>
        public partial class CustomersByMonetaryScoreConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override void Identify()
            {
                DefineConfig("توزیع نمره ارزش", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.MonetaryScore), "نمره ارزش");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش لیست مشتریان با جزئیات RFM
        /// </summary>
        public partial class CustomersWithRfmDetailsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("لیست مشتریان با جزئیات RFM", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Customer.FirstName), "نام");
                DisplayColumn(nameof(Customer.LastName), "نام خانوادگی");
                DisplayColumn(nameof(Customer.MobileNo), "موبایل");
                DisplayColumn(nameof(Customer.RfmSegment), "دسته RFM");
                DisplayColumn(nameof(Customer.RecencyScore), "نمره تازگی");
                DisplayColumn(nameof(Customer.FrequencyScore), "نمره تکرار");
                DisplayColumn(nameof(Customer.MonetaryScore), "نمره ارزش");
                DisplayColumn(nameof(Customer.LastInteractionDate), "آخرین تعامل");
                DisplayColumn(nameof(Customer.TotalTransactionValue), "ارزش کل");
            }
        }
    }
}
