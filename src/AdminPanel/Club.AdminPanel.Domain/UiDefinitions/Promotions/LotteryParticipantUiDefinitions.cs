using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Promotions;

public partial class LotteryParticipantUiDefinitions : CRUDDefinition<LotteryParticipant>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(LotteryParticipant.Lottery),
                        nameof(LotteryParticipant.Customer),
                        nameof(LotteryParticipant.IsWinner),
                        nameof(LotteryParticipant.Award),
                        nameof(LotteryParticipant.AwardAmount),
                        nameof(LotteryParticipant.ParticipatedAt),
                        nameof(LotteryParticipant.AnnouncedAt),
                        nameof(LotteryParticipant.IsAwardDistributed),
                        nameof(LotteryParticipant.AwardDistributedAt)
                        );
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(LotteryParticipant.Lottery),
                       nameof(LotteryParticipant.Customer),
                       nameof(LotteryParticipant.IsWinner),
                       nameof(LotteryParticipant.Award),
                       nameof(LotteryParticipant.AwardAmount),
                       nameof(LotteryParticipant.ParticipatedAt),
                       nameof(LotteryParticipant.AnnouncedAt),
                       nameof(LotteryParticipant.IsAwardDistributed),
                       nameof(LotteryParticipant.AwardDistributedAt),
                       nameof(LotteryParticipant.AwardAsset)
                       );
    }
    
    protected override void EditFormSubTables(CUDForm form)
    {
        // Sub-tables can be added here if needed
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Lottery Participation Reports
        // =====================================================

        /// <summary>
        /// گزارش مشارکت در قرعه‌کشی‌ها
        /// </summary>
        public partial class LotteryParticipationConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("مشارکت در قرعه‌کشی", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(LotteryParticipant.LotteryId), "قرعه‌کشی");
                Count(null, "تعداد شرکت‌کنندگان");
                
                OrderByDesc("COUNT"); // نزولی - پرمشارکت‌ترین
            }
        }

        /// <summary>
        /// گزارش برندگان قرعه‌کشی
        /// </summary>
        public partial class LotteryWinnersConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(LotteryParticipant.IsWinner)} == true";
            
            protected override void Identify()
            {
                DefineConfig("برندگان قرعه‌کشی", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(LotteryParticipant.LotteryId), "قرعه‌کشی");
                DisplayColumn(nameof(LotteryParticipant.CustomerId), "مشتری");
                DisplayColumn(nameof(LotteryParticipant.AwardId), "پاداش");
                DisplayColumn(nameof(LotteryParticipant.AwardAmount), "مبلغ");
                DisplayColumn(nameof(LotteryParticipant.AnnouncedAt), "تاریخ اعلام");
                DisplayColumn(nameof(LotteryParticipant.IsAwardDistributed), "توزیع شده");
                
                OrderByDesc(nameof(LotteryParticipant.AnnouncedAt)); // نزولی - جدیدترین
            }
        }

        /// <summary>
        /// گزارش پاداش‌های توزیع نشده
        /// </summary>
        public partial class UndistributedAwardsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(LotteryParticipant.IsWinner)} == true && {nameof(LotteryParticipant.IsAwardDistributed)} == false";
            
            protected override void Identify()
            {
                DefineConfig("پاداش‌های توزیع نشده", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(LotteryParticipant.LotteryId), "قرعه‌کشی");
                DisplayColumn(nameof(LotteryParticipant.CustomerId), "مشتری");
                DisplayColumn(nameof(LotteryParticipant.AwardId), "پاداش");
                DisplayColumn(nameof(LotteryParticipant.AwardAmount), "مبلغ");
                DisplayColumn(nameof(LotteryParticipant.AnnouncedAt), "تاریخ اعلام");
                
                OrderBy(nameof(LotteryParticipant.AnnouncedAt)); // صعودی - قدیمی‌ترین (اولویت توزیع)
            }
        }
    }
}
