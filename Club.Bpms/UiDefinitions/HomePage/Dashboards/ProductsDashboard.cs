using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using ProductServiceUiDefinitions = Club.Bpms.UiDefinitions.Products.ProductUiDefinitions;
using EventLogUiDefinitions = Club.Bpms.UiDefinitions.Events.EventLogUiDefinitions;

namespace Club.Bpms.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        // =====================================================
        // 8. داشبورد محصولات
        // =====================================================
        public partial class ProductsDashboard : DashboardConfigDefinition
        {
            protected override string Title => "محصولات";
            protected override List<string>? Roles => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for Products & Services Dashboard
            // =====================================================

            public partial class ProductOverviewDiv : DashboardDivDefinition
            {
                public override string Title => "نمای کلی محصولات";
                public override long Width => 12;
                public override bool IsRow => true;

                public partial class ProductsByCategoryWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.ProductsByCategoryConfig>
                {
                    public override string Title => "توزیع محصولات به تفکیک دسته";
                    public override long Width => 6;
                }

                public partial class ProductsByTypeWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.ProductsByTypeConfig>
                {
                    public override string Title => "محصولات به تفکیک نوع";
                    public override long Width => 6;
                }
            }

            public partial class ActiveProductsDiv : DashboardDivDefinition
            {
                public override string Title => "محصولات فعال";
                public override long Width => 12;

                public partial class ActiveProductsWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.ActiveProductsConfig>
                {
                    public override string Title => "لیست محصولات فعال";
                    protected override int? MaxRecordCount => 20;
                    public override long Width => 12;
                }
            }

            public partial class PopularityAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل محبوبیت";
                public override long Width => 6;

                public partial class PopularProductsWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.PopularProductsConfig>
                {
                    public override string Title => "محبوب‌ترین محصولات";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class ProductEventsDiv : DashboardDivDefinition
            {
                public override string Title => "رویدادهای محصولات";
                public override long Width => 6;

                public partial class EventLogByProductWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByProductConfig>
                {
                    public override string Title => "فعالیت محصولات";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class HighPointProductsDiv : DashboardDivDefinition
            {
                public override string Title => "محصولات پرامتیاز";
                public override long Width => 6;

                public partial class HighPointProductsWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.HighPointProductsConfig>
                {
                    public override string Title => "محصولات با بیشترین امتیاز";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class TenantAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل سازمان‌ها";
                public override long Width => 6;

                public partial class ProductsByTenantWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.ProductsByTenantConfig>
                {
                    public override string Title => "محصولات به تفکیک سازمان";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class RepeatPurchaseDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل وفاداری مشتری";
                public override long Width => 12;

                public partial class ProductRepeatPurchaseWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.ProductRepeatPurchaseConfig>
                {
                    public override string Title => "نرخ تکرار خرید محصولات";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }

            public partial class CustomerLifetimeValueDiv : DashboardDivDefinition
            {
                public override string Title => "ارزش طول عمر مشتری (CLV)";
                public override long Width => 12;

                public partial class ProductCLVWidget : DashboardDivWidgetDefinition<ProductServiceUiDefinitions, ProductServiceUiDefinitions.PublicReport, ProductServiceUiDefinitions.PublicReport.ProductCLVConfig>
                {
                    public override string Title => "محصولات براساس CLV";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }
            }
        }
    }
}



