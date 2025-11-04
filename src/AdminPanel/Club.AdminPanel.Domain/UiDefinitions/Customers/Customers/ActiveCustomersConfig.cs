using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Customers.Customers;

public partial class CustomerUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// کانفیگ گزارش مشتریان فعال
        /// </summary>
        public partial class ActiveCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Customer.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("مشتریان فعال", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Count(null, "تعداد مشتریان فعال");
            }
        }
    }
}
