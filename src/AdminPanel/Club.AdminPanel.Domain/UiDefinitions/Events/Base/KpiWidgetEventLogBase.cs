using Club.Domain.Entities.Events.Data;

namespace Club.AdminPanel.Domain.UiDefinitions.Events.Base;

using EventLog = EventLog;
using EventLogUiDefinitions = Club.AdminPanel.Domain.UiDefinitions.Events.EventLogUiDefinitions;

public abstract class KpiWidgetEventLogBase<TReportConfig>
    : KpiWidgetBase<EventLog, EventLogUiDefinitions.PublicReport, TReportConfig>
    where TReportConfig : ReportConfigDefinition
{
}









