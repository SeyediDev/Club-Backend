namespace Club.AdminPanel.Domain.UiDefinitions.Promotions.Base;

using Promotion = Club.Domain.Entities.Promotions.Promotion;
using PromotionUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Promotions.PromotionUiDefinitions;

public abstract class WidgetPromotionBase<TReportConfig>
    : DashboardDivWidgetDefinition<Promotion, PromotionUiDefinitions.PublicReport, TReportConfig>
    where TReportConfig : ReportConfigDefinition
{
}









