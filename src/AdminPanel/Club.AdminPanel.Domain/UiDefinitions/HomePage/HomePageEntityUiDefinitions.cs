using Club.Domain.Entities.Channels;
using Club.Domain.Entities.Events.Data;

namespace Club.AdminPanel.Domain.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions : CRUDDefinition<HomePageEntity>
{
    private static readonly List<string> DefaultRoles =
    [
        Neo.Domain.Constants.Roles.Admin,
        ClubRoles.Manager
    ];

    public override List<string>? Roles => DefaultRoles;

    protected override void Forms()
    {
        //DefineForm<ManagerHomePage>();
        //DefineForm<Default>();
    }

    public partial class HomePageDashboard : DashboardDefinition
    {
        public override List<string>? Roles => DefaultRoles;

        protected override Form Identify()
        {
            return DefineDashboard("داشبورد اصلی باشگاه مشتریان");
        }

        protected override void Filters()
        {
        }

        protected override void DataSources()
        {
            base.DataSources();
            AddReport<Customer>();
            AddReport<CustomerTenant>();
            AddReport<CustomerTransaction>();
            AddReport<RewardAsset>();
            AddReport<Reward>();
            AddReport<Product>();
            AddReport<ProductFitAnalysis>();
            AddReport<CustomerSegment>();
            AddReport<EventType>();
            AddReport<EventChannel>();
            AddReport<EventLog>();
            AddReport<Promotion>();
            AddReport<Point>();
            AddReport<Survey>();
        }
    }
}
