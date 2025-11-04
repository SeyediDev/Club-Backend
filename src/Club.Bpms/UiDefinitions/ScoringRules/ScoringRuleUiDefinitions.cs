using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.ScoringRules;

public partial class ClubRuleDefinitions : CRUDDefinition<ScoringRule>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(ScoringRule.Title),
                        nameof(ScoringRule.Tenant),
                        nameof(ScoringRule.CreateDate)
                        );
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(ScoringRule.Title),
                       nameof(ScoringRule.Tenant)
                       );
    }
    
    protected override void CUDFormsSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(ScoringRuleTriggerCondition), nameof(ScoringRuleTriggerCondition.ScoringRule), "Sub",
            "شرایط فراخوانی", null, false, eControlTypeId.MultiTab);
        form.AddSubTable(nameof(ScoringRuleAction), nameof(ScoringRuleAction.ScoringRule), "Sub",
            "عملیات", null, false, eControlTypeId.MultiTab);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// گزارش قوانین امتیازدهی فعال
        /// </summary>
        public partial class ActiveScoringRulesConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("قوانین امتیازدهی فعال", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(ScoringRule.Title), "عنوان قانون");
                DisplayColumn(nameof(ScoringRule.Tenant), "سازمان");
                DisplayColumn(nameof(ScoringRule.CreateDate), "تاریخ ایجاد");
                OrderByDesc(nameof(ScoringRule.CreateDate));
            }
        }

        /// <summary>
        /// گزارش تعداد قوانین به تفکیک سازمان
        /// </summary>
        public partial class ScoringRulesByTenantConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("قوانین به تفکیک سازمان", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(ScoringRule.Tenant), "سازمان");
                Count(null, "تعداد قوانین");
                OrderByDesc("COUNT");
            }
        }

        /// <summary>
        /// گزارش جدیدترین قوانین امتیازدهی
        /// </summary>
        public partial class RecentScoringRulesConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("جدیدترین قوانین", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(ScoringRule.Title), "عنوان");
                DisplayColumn(nameof(ScoringRule.Tenant), "سازمان");
                DisplayColumn(nameof(ScoringRule.CreateDate), "تاریخ ایجاد");
                OrderByDesc(nameof(ScoringRule.CreateDate));
            }
        }
    }
}