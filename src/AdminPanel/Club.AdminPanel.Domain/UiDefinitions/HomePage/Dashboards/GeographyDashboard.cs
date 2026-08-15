using Club.AdminPanel.Domain.UiDefinitions.CustomerTenants.Base;
using CustomerTenantUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Customers.CustomerTenants.CustomerTenantUiDefinitions;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        /// <summary>
        /// تب توزیع: نمایش توزیع مشتریان روی نقشه جهان و نقشه ایران
        /// </summary>
        public class GeographyDashboard : DashboardConfigDefinition
        {
            protected override string Title => "توزیع";
            protected override List<string> Roles => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst];
            protected override string Icon => "list-checklist";

			public class IranMapWidget : WidgetCustomerTenantBase<CustomerTenantUiDefinitions.PublicReport.IranGeographicDistributionConfig>
            {
                public override string Title => "نقشه توزیع مشتریان - ایران";
                protected override int? HeightInPixels => 320;
                public override int Width => 9;
            }
			public class ProvinceBarWidget : WidgetCustomerTenantBase<CustomerTenantUiDefinitions.PublicReport.ProvinceBarDistributionConfig>
			{
				public override string Title => "نمودار توزیع استانی";
				protected override int? HeightInPixels => 320;
				protected override int? MaxRecordCount { get; } = 32;
				public override int Width => 3;
			}
			public class ProvinceTreeMapWidget : WidgetCustomerTenantBase<CustomerTenantUiDefinitions.PublicReport.ProvinceTreeMapConfig>
			{
				public override string Title => "درخت‌نقشه توزیع استان‌ها (دریل‌داون شهر)";
				protected override int? HeightInPixels => 400;
				public override int Width => 12;
			}
		}
	}
}