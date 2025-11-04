using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using PromotionUiDefinitions = Club.Bpms.UiDefinitions.Promotions.PromotionUiDefinitions;

namespace Club.Bpms.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{

    public partial class HomePageDashboard
    {
        // =====================================================
        // 3. داشبورد کمپین‌های بازاریابی
        // =====================================================
        public partial class MarketingCampaignsDashboard : DashboardConfigDefinition
        {
            protected override string Title => "کمپین‌های بازاریابی";
            protected override List<string>? Roles => [ClubRoles.MarketingManager];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for Marketing Campaigns Dashboard
            // =====================================================

            public partial class ActiveCampaignsDiv : DashboardDivDefinition
            {
                public override string Title => "کمپین‌های فعال";
                public override long Width => 12;

                public partial class ActiveCampaignsWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.ActiveCampaignsConfig>
                {
                    public override string Title => "کمپین‌های فعال";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class CampaignROIDiv : DashboardDivDefinition
            {
                public override string Title => "بازگشت سرمایه کمپین (ROI)";
                public override long Width => 6;

                public partial class CampaignRoiWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.CampaignRoiAnalysisConfig>
                {
                    public override string Title => "تحلیل ROI";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class MessageEffectivenessDiv : DashboardDivDefinition
            {
                public override string Title => "اثربخشی پیام‌ها";
                public override long Width => 6;

                public partial class MessageFunnelWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.MessageEngagementFunnelConfig>
                {
                    public override string Title => "فانل تعامل";
                    protected override int? MaxRecordCount => 5;
                    public override long Width => 12;
                }
            }

            public partial class DeliveryRateDiv : DashboardDivDefinition
            {
                public override string Title => "نرخ تحویل";
                public override long Width => 6;

                public partial class DeliveryRateWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.MessageDeliveryRateConfig>
                {
                    public override string Title => "نرخ تحویل پیام‌ها";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class ResponseAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل پاسخگویی";
                public override long Width => 6;

                public partial class ConversionRateWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.ConversionRateAnalysisConfig>
                {
                    public override string Title => "نرخ تبدیل";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class CACAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل هزینه جذب مشتری (CAC)";
                public override long Width => 12;

                public partial class CacWidget : DashboardDivWidgetDefinition<PromotionUiDefinitions, PromotionUiDefinitions.PublicReport, PromotionUiDefinitions.PublicReport.CustomerAcquisitionCostConfig>
                {
                    public override string Title => "هزینه جذب مشتری";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }
        }
    }
}
