using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Points;

public partial class PointUiDefinitions : CRUDDefinition<Point>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Point.Title),
                        nameof(Point.PointType),
                        nameof(Point.Tenant)
                        );
        form.AddOrderBy(nameof(Point.Tenant));
        form.AddOrderBy(nameof(Point.PointType));
    }
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Point.Title),
                        nameof(Point.PointType),
                        nameof(Point.Tenant),
                        nameof(Point.AutoVisit),
                        nameof(Point.Visible)
                        );
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        form.AddSubTable(nameof(PointLevel), nameof(PointLevel.Point), "Sub",
            "سطوح امتیازی", null, false, eControlTypeId.MultiTab);
        form.AddSubTable(nameof(PointBudget), nameof(PointBudget.Point), "Sub",
            "بودجه امتیازی", null, false, eControlTypeId.MultiTab);
        form.AddSubTable(nameof(PointConversionRate), nameof(PointConversionRate.FromPoint), "Sub",
            "نرخ تبدیل امتیاز", null, false, eControlTypeId.MultiTab);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// گزارش امتیازات به تفکیک نوع
        /// </summary>
        public partial class PointsByTypeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("امتیازات به تفکیک نوع", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Point.PointType), "نوع امتیاز");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش امتیازات قابل مشاهده
        /// </summary>
        public partial class VisiblePointsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Point.Visible)} == true";
            
            protected override void Identify()
            {
                DefineConfig("امتیازات قابل مشاهده", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Point.Title), "عنوان");
                DisplayColumn(nameof(Point.PointType), "نوع امتیاز");
                DisplayColumn(nameof(Point.Tenant), "سازمان");
                DisplayColumn(nameof(Point.AutoVisit), "بازدید خودکار");
            }
        }

        /// <summary>
        /// گزارش امتیازات به تفکیک سازمان
        /// </summary>
        public partial class PointsByTenantConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("امتیازات به تفکیک سازمان", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Point.Tenant), "سازمان");
                Count(null, "تعداد امتیازات");
                OrderByDesc("COUNT");
            }
        }

        /// <summary>
        /// گزارش امتیازات با بازدید خودکار
        /// </summary>
        public partial class AutoVisitPointsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Point.AutoVisit)} == true";
            
            protected override void Identify()
            {
                DefineConfig("امتیازات با بازدید خودکار", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Point.Title), "عنوان");
                DisplayColumn(nameof(Point.PointType), "نوع امتیاز");
                DisplayColumn(nameof(Point.Tenant), "سازمان");
            }
        }
    }
}
