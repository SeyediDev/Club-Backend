using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Customer Growth Reports
        // =====================================================

        /// <summary>
        /// گزارش رشد مشتریان به تفکیک ماه
        /// </summary>
        public partial class CustomerGrowthByMonthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("رشد مشتریان ماهانه", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(null, "تعداد مشتریان جدید");
            }
        }

        /// <summary>
        /// گزارش رشد تجمعی مشتریان
        /// </summary>
        public partial class CumulativeCustomerGrowthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("رشد تجمعی مشتریان", ReportViewType.Chart, Report.ChartType.Area);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(null, "تعداد کل");
            }
        }

        /// <summary>
        /// گزارش نرخ رشد مشتریان
        /// </summary>
        public partial class CustomerGrowthRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override void Identify()
            {
                DefineConfig("نرخ رشد مشتریان", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(null, "تعداد مشتریان جدید");
            }
        }

        /// <summary>
        /// گزارش مقایسه مشتریان جدید با مشتریان از دست رفته
        /// </summary>
        public partial class NewVsChurnedCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("مشتریان جدید در مقابل از دست رفته", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(null, "مشتریان جدید");
            }
        }

        /// <summary>
        /// گزارش توزیع مشتریان فعال در مقابل غیرفعال
        /// </summary>
        public partial class ActiveVsInactiveCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("مشتریان فعال/غیرفعال", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Customer.IsActive), "وضعیت");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش مشتریان جدید به تفکیک هفته
        /// </summary>
        public partial class NewCustomersByWeekConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("مشتریان جدید هفتگی", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtWeek", "هفته");
                Count(null, "تعداد مشتریان");
            }
        }

        /// <summary>
        /// گزارش مشتریان جدید امروز/این هفته/این ماه
        /// </summary>
        public partial class NewCustomersTimeRangeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override void Identify()
            {
                DefineConfig("مشتریان جدید بازه زمانی", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Count(null, "تعداد");
            }
        }
    }
}
