using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Promotions;

public partial class LotteryUiDefinitions : CRUDDefinition<Lottery>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Lottery.Title),
                        nameof(Lottery.LotteryType),
                        nameof(Lottery.FromDate),
                        nameof(Lottery.ToDate),
                        nameof(Lottery.IsScheduled),
                        nameof(Lottery.Tenant),
                        nameof(Lottery.CustomerSegment)
                        );
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Lottery.Title),
                       nameof(Lottery.Tenant),
                       nameof(Lottery.CustomerSegment),
                       nameof(Lottery.LotteryType),
                       nameof(Lottery.FromDate),
                       nameof(Lottery.ToDate),
                       nameof(Lottery.IsScheduled),
                       nameof(Lottery.SchedulingKind),
                       nameof(Lottery.DayOfWeek),
                       nameof(Lottery.DayOfMonth),
                       nameof(Lottery.Month),
                       nameof(Lottery.DayOfYear),
                       nameof(Lottery.Hour),
                       nameof(Lottery.Minute)
                       );
    }
    
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(LotteryReward), nameof(LotteryReward.Lottery), "Sub",
            "پاداش‌ها", null, true, eControlTypeId.MultiTab);
        
        form.AddSubTable(nameof(LotteryParticipant), nameof(LotteryParticipant.Lottery), "Sub",
            "شرکت‌کنندگان", null, false, eControlTypeId.MultiTab);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Lottery Reports
        // =====================================================

        /// <summary>
        /// گزارش قرعه‌کشی‌های فعال
        /// </summary>
        public partial class ActiveLotteriesConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Lottery.ToDate)} >= DateTime.Now";
            
            protected override void Identify()
            {
                DefineConfig("قرعه‌کشی‌های فعال", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Lottery.Title), "عنوان");
                DisplayColumn(nameof(Lottery.LotteryType), "نوع");
                DisplayColumn(nameof(Lottery.FromDate), "از تاریخ");
                DisplayColumn(nameof(Lottery.ToDate), "تا تاریخ");
                
                OrderByDesc(nameof(Lottery.FromDate)); // نزولی - جدیدترین
            }
        }

        /// <summary>
        /// گزارش مشارکت در قرعه‌کشی‌ها
        /// </summary>
        public partial class LotteryParticipationStatsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("آمار مشارکت در قرعه‌کشی", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Lottery.Title), "قرعه‌کشی");
                Count(null, "تعداد شرکت‌کنندگان");
            }
        }

        /// <summary>
        /// گزارش قرعه‌کشی‌ها به تفکیک نوع
        /// </summary>
        public partial class LotteriesByTypeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("قرعه‌کشی‌ها به تفکیک نوع", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Lottery.LotteryType), "نوع قرعه‌کشی");
                Count(null, "تعداد");
            }
        }
    }
}

