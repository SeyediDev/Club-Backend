using Neo.Bpms.Domain.Entities.Cmmn.Common;
using Neo.Bpms.Domain.Model.UI.Forms;
using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using Club.Domain.Entities.Rewards;

namespace Club.Bpms.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions : CRUDDefinition<HomePageEntity>
{
    protected override void Forms()
    {
        //DefineForm<ManagerHomePage>();
        //DefineForm<Default>();
    }

    public partial class HomePageDashboard : DashboardDefinition
    {
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
            AddReport<CustomerTransaction>();
            AddReport<RewardAsset>();
            AddReport<Reward>();
            AddReport<Product>();
            AddReport<EventType>();
            AddReport<EventChannel>();
            AddReport<EventLog>();
            AddReport<Promotion>();
        }
    }
}
