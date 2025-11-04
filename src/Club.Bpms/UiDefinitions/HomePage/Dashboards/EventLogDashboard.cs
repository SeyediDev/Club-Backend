using Neo.Bpms.Domain.Modeling.MetaDefinitions.Dashboards;
using EventLogUiDefinitions = Club.Bpms.UiDefinitions.Events.EventLogUiDefinitions;
using EventTypeUiDefinitions = Club.Bpms.UiDefinitions.Events.EventTypeUiDefinitions;
using EventChannelUiDefinitions = Club.Bpms.UiDefinitions.Events.EventChannelUiDefinitions;

namespace Club.Bpms.UiDefinitions.HomePage;

public partial class HomePageEntityUiDefinitions
{
    public partial class HomePageDashboard
    {
        // =====================================================
        // 6. داشبورد رویدادها و تحلیل فعالیت
        // =====================================================
        public partial class EventLogDashboard : DashboardConfigDefinition
        {
            protected override string Title => "رویدادها و تحلیل فعالیت";
            protected override List<string>? Roles => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst, ClubRoles.Manager];
            protected override bool IsDefault => false;

            // =====================================================
            // Div Definitions for EventLog Dashboard
            // =====================================================

            public partial class EventOverviewDiv : DashboardDivDefinition
            {
                public override string Title => "نمای کلی رویدادها";
                public override long Width => 12;
                public override bool IsRow => true;

                public partial class EventLogByMonthWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByMonthConfig>
                {
                    public override string Title => "رویدادهای ماهانه";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 8;
                }

                public partial class EventLogByTriggerTypeWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByTriggerTypeConfig>
                {
                    public override string Title => "به تفکیک نوع فعال‌سازی";
                    public override long Width => 4;
                }
            }

            public partial class EventChannelsDiv : DashboardDivDefinition
            {
                public override string Title => "کانال‌های رویداد";
                public override long Width => 6;

                public partial class EventLogByChannelWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByChannelConfig>
                {
                    public override string Title => "رویدادها به تفکیک کانال";
                    public override long Width => 12;
                }
            }

            public partial class EventTypesDiv : DashboardDivDefinition
            {
                public override string Title => "انواع رویدادها";
                public override long Width => 6;

                public partial class EventLogByEventTypeWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByEventTypeConfig>
                {
                    public override string Title => "رویدادها به تفکیک نوع";
                    public override long Width => 12;
                }
            }

            public partial class CustomerActivityDiv : DashboardDivDefinition
            {
                public override string Title => "فعالیت مشتریان";
                public override long Width => 6;

                public partial class MostActiveCustomersWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.MostActiveCustomersConfig>
                {
                    public override string Title => "فعال‌ترین مشتریان";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class ActiveUsersDiv : DashboardDivDefinition
            {
                public override string Title => "کاربران فعال";
                public override long Width => 6;

                public partial class DailyActiveUsersWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.DailyActiveUsersConfig>
                {
                    public override string Title => "کاربران فعال روزانه (DAU)";
                    protected override int? MaxRecordCount => 30;
                    public override long Width => 12;
                }

                public partial class MonthlyActiveUsersWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.MonthlyActiveUsersConfig>
                {
                    public override string Title => "کاربران فعال ماهانه (MAU)";
                    protected override int? MaxRecordCount => 12;
                    public override long Width => 12;
                }
            }

            public partial class PromotionEventsDiv : DashboardDivDefinition
            {
                public override string Title => "رویدادهای پویش‌ها";
                public override long Width => 12;

                public partial class EventLogByPromotionWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByPromotionConfig>
                {
                    public override string Title => "رویدادهای مرتبط با پویش";
                    protected override int? MaxRecordCount => 20;
                    public override long Width => 12;
                }
            }

            public partial class RewardEventsDiv : DashboardDivDefinition
            {
                public override string Title => "رویدادهای پاداش‌ها";
                public override long Width => 6;

                public partial class EventLogByRewardWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByRewardConfig>
                {
                    public override string Title => "رویدادهای مرتبط با پاداش";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class ProductEventsDiv : DashboardDivDefinition
            {
                public override string Title => "رویدادهای محصولات";
                public override long Width => 6;

                public partial class EventLogByProductWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByProductConfig>
                {
                    public override string Title => "رویدادهای محصولات";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class SystemHealthDiv : DashboardDivDefinition
            {
                public override string Title => "سلامت سیستم";
                public override long Width => 12;

                public partial class SystemActivityWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.SystemActivityDailyConfig>
                {
                    public override string Title => "فعالیت روزانه سیستم";
                    protected override int? MaxRecordCount => 30;
                    public override long Width => 8;
                }

                public partial class RecentEventsWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.RecentEventsConfig>
                {
                    public override string Title => "آخرین رویدادها";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 4;
                }
            }

            public partial class ShamsiAnalysisDiv : DashboardDivDefinition
            {
                public override string Title => "تحلیل ماه‌های شمسی";
                public override long Width => 12;

                public partial class EventLogByShamsiMonthWidget : DashboardDivWidgetDefinition<EventLogUiDefinitions, EventLogUiDefinitions.PublicReport, EventLogUiDefinitions.PublicReport.EventLogByShamsiMonthConfig>
                {
                    public override string Title => "رویدادها به تفکیک ماه شمسی";
                    public override long Width => 12;
                }
            }

            public partial class EventTypesManagementDiv : DashboardDivDefinition
            {
                public override string Title => "مدیریت انواع رویداد";
                public override long Width => 6;

                public partial class AllEventTypesWidget : DashboardDivWidgetDefinition<EventTypeUiDefinitions, EventTypeUiDefinitions.PublicReport, EventTypeUiDefinitions.PublicReport.AllEventTypesConfig>
                {
                    public override string Title => "لیست انواع رویدادها";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }

                public partial class MostUsedEventTypesWidget : DashboardDivWidgetDefinition<EventTypeUiDefinitions, EventTypeUiDefinitions.PublicReport, EventTypeUiDefinitions.PublicReport.MostUsedEventTypesConfig>
                {
                    public override string Title => "پرکاربردترین انواع رویداد";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }

            public partial class EventChannelsManagementDiv : DashboardDivDefinition
            {
                public override string Title => "مدیریت کانال‌ها";
                public override long Width => 6;

                public partial class AllEventChannelsWidget : DashboardDivWidgetDefinition<EventChannelUiDefinitions, EventChannelUiDefinitions.PublicReport, EventChannelUiDefinitions.PublicReport.AllEventChannelsConfig>
                {
                    public override string Title => "لیست کانال‌های رویداد";
                    protected override int? MaxRecordCount => 15;
                    public override long Width => 12;
                }

                public partial class MostUsedChannelsWidget : DashboardDivWidgetDefinition<EventChannelUiDefinitions, EventChannelUiDefinitions.PublicReport, EventChannelUiDefinitions.PublicReport.MostUsedChannelsConfig>
                {
                    public override string Title => "پرکاربردترین کانال‌ها";
                    protected override int? MaxRecordCount => 10;
                    public override long Width => 12;
                }
            }
        }
    }
}


