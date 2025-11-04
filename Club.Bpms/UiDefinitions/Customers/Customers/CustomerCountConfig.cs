using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// کانفیگ گزارش تعداد کل مشتریان
        /// </summary>
        public partial class CustomerCountConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("تعداد کل مشتریان", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Count(null, "تعداد کل مشتریان");
            }
        }
    }
}
