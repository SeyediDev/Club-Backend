using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Events;

public partial class EventTypeUiDefinitions : CRUDDefinition<EventType>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(EventType.Title),
                        nameof(EventType.Key)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(EventType.Title),
                       nameof(EventType.Key)
                       );
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(EventTypeParameter), nameof(EventTypeParameter.EventType), "Sub",
            "پارامترها", null, false, eControlTypeId.MultiTab);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// گزارش لیست انواع رویدادها
        /// </summary>
        public partial class AllEventTypesConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("لیست انواع رویدادها", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(EventType.Title), "عنوان");
                DisplayColumn(nameof(EventType.Key), "کلید");
                OrderBy(nameof(EventType.Title));
            }
        }

        /// <summary>
        /// گزارش پرکاربردترین انواع رویداد
        /// </summary>
        public partial class MostUsedEventTypesConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("پرکاربردترین انواع رویداد", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(EventType.Title), "نوع رویداد");
                Count(null, "تعداد استفاده");
                OrderByDesc("COUNT");
            }
        }
    }
}
