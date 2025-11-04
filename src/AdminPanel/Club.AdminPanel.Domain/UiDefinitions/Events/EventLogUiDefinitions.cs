using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Events;

public partial class EventLogUiDefinitions : CRUDDefinition<EventLog>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(EventLog.CustomerId),
                        nameof(EventLog.EventTypeId),
                        nameof(EventLog.TriggerType),
                        nameof(EventLog.EventChannelId),
                        nameof(EventLog.CreateDate)
                        );
    }

    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(EventLog.CustomerId),
                       nameof(EventLog.EventTypeId),
                       nameof(EventLog.TriggerType),
                       nameof(EventLog.EventChannelId),
                       nameof(EventLog.PromotionId),
                       nameof(EventLog.PointLevelId),
                       nameof(EventLog.AwardId),
                       nameof(EventLog.TenantProductOrServiceId),
                       nameof(EventLog.AssetId)
                       );
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Event Analytics Reports
        // =====================================================

        /// <summary>
        /// گزارش رویدادها به تفکیک ماه
        /// </summary>
        public partial class EventLogByMonthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادهای ماهانه", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(null, "تعداد رویدادها");
            }
        }

        /// <summary>
        /// گزارش رویدادها به تفکیک کانال
        /// </summary>
        public partial class EventLogByChannelConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادها به تفکیک کانال", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.EventChannelId), "کانال");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش رویدادها به تفکیک نوع رویداد
        /// </summary>
        public partial class EventLogByEventTypeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادها به تفکیک نوع", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.EventTypeId), "نوع رویداد");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش رویدادهای مرتبط با پویش‌ها
        /// </summary>
        public partial class EventLogByPromotionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.MarketingManager]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادهای مرتبط با پویش", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(EventLog.PromotionId), "پویش");
                DisplayColumn(nameof(EventLog.CustomerId), "مشتری");
                DisplayColumn(nameof(EventLog.CreateDate), "تاریخ");
                DisplayColumn(nameof(EventLog.EventTypeId), "نوع رویداد");
                
                OrderByDesc(nameof(EventLog.CreateDate)); // نزولی - جدیدترین
            }
        }

        /// <summary>
        /// گزارش فعال‌ترین مشتریان (بر اساس تعداد رویدادها)
        /// </summary>
        public partial class MostActiveCustomersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("فعال‌ترین مشتریان", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.CustomerId), "مشتری");
                Count(null, "تعداد رویدادها");
                
                OrderByDesc("COUNT"); // نزولی - بیشترین رویداد
            }
        }

        /// <summary>
        /// گزارش رویدادها به تفکیک نوع فعال‌سازی
        /// </summary>
        public partial class EventLogByTriggerTypeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادها به تفکیک نوع فعال‌سازی", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.TriggerType), "نوع فعال‌سازی");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش رویدادهای مرتبط با پاداش‌ها
        /// </summary>
        public partial class EventLogByRewardConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادهای مرتبط با پاداش", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.AwardId), "پاداش");
                Count(null, "تعداد دریافت");
                
                OrderByDesc("COUNT"); // نزولی - پرطرفدارترین پاداش
            }
        }

        /// <summary>
        /// گزارش رویدادهای مرتبط با محصولات
        /// </summary>
        public partial class EventLogByProductConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادهای محصولات", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.TenantProductOrServiceId), "محصول");
                Count(null, "تعداد رویداد");
                
                OrderByDesc("COUNT"); // نزولی - پرطرفدارترین
            }
        }

        /// <summary>
        /// گزارش فعالیت سیستم روزانه
        /// </summary>
        public partial class SystemActivityDailyConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin]; }
            
            protected override void Identify()
            {
                DefineConfig("فعالیت سیستم روزانه", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtDay", "روز");
                Count(null, "تعداد رویدادها");
            }
        }

        /// <summary>
        /// گزارش کاربران فعال روزانه (DAU)
        /// </summary>
        public partial class DailyActiveUsersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("کاربران فعال روزانه (DAU)", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtDay", "روز");
                Count(nameof(EventLog.CustomerId), "تعداد کاربران منحصر به فرد");
            }
        }

        /// <summary>
        /// گزارش کاربران فعال ماهانه (MAU)
        /// </summary>
        public partial class MonthlyActiveUsersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("کاربران فعال ماهانه (MAU)", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(nameof(EventLog.CustomerId), "تعداد کاربران منحصر به فرد");
            }
        }

        /// <summary>
        /// گزارش رویدادها به تفکیک ماه شمسی
        /// </summary>
        public partial class EventLogByShamsiMonthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("رویدادها به تفکیک ماه شمسی", ReportViewType.Chart, Report.ChartType.Column);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventLog.ShamsiMonth), "ماه شمسی");
                Count(null, "تعداد رویدادها");
            }
        }

        /// <summary>
        /// گزارش آخرین رویدادها
        /// </summary>
        public partial class RecentEventsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("آخرین رویدادها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(EventLog.CustomerId), "مشتری");
                DisplayColumn(nameof(EventLog.EventTypeId), "نوع رویداد");
                DisplayColumn(nameof(EventLog.TriggerType), "نوع فعال‌سازی");
                DisplayColumn(nameof(EventLog.CreateDate), "تاریخ");
                
                OrderByDesc(nameof(EventLog.CreateDate)); // نزولی - جدیدترین
            }
        }
    }
}

