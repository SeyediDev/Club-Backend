using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// کانفیگ گزارش مشتریان جدید (30 روز اخیر)
        /// </summary>
        public partial class NewCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Customer.CreateDate)} >= DateTime.Now.AddDays(-30)";
            
            protected override void Identify()
            {
                DefineConfig("مشتریان جدید", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Count(null, "تعداد مشتریان جدید");
            }
        }
    }
}
