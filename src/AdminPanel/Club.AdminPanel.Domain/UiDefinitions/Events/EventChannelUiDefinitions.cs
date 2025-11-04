using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Events;

public partial class EventChannelUiDefinitions : CRUDDefinition<EventChannel>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(EventChannel.Title),
                        nameof(EventChannel.Key));
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(EventChannel.Title),
                       nameof(EventChannel.Key));
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(EventChannelValidEventType), nameof(EventChannelValidEventType.EventChannel), "Sub",
            "نوع رویدادهای مجاز", null, true, eControlTypeId.MultiTab);
        form.AddSubTable(nameof(EventChannelValidIp), nameof(EventChannelValidIp.EventChannel), "Sub",
            "آدرس های مجاز", null, true, eControlTypeId.MultiTab);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// گزارش لیست کانال‌های رویداد
        /// </summary>
        public partial class AllEventChannelsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("لیست کانال‌های رویداد", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(EventChannel.Title), "عنوان");
                DisplayColumn(nameof(EventChannel.Key), "کلید");
                OrderBy(nameof(EventChannel.Title));
            }
        }

        /// <summary>
        /// گزارش پرکاربردترین کانال‌ها
        /// </summary>
        public partial class MostUsedChannelsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("پرکاربردترین کانال‌ها", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventChannel.Title), "کانال");
                Count(null, "تعداد استفاده");
                OrderByDesc("COUNT");
            }
        }
    }
}
