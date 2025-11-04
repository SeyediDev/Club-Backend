using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Customers.CustomerSegments;

public partial class CustomerSegmentUiDefinitions
{
    public new partial class PublicReport: CRUDDefinition.PublicReport
    {
        // =====================================================
        // Segment Analytics Reports
        // =====================================================

        /// <summary>
        /// گزارش توزیع جوامع مشتریان
        /// </summary>
        public partial class SegmentDistributionConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("توزیع جوامع مشتریان", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerSegment.Title), "عنوان جامعه");
                Sum(nameof(CustomerSegment.ActualSize), "تعداد اعضا");
            }
        }

        /// <summary>
        /// گزارش مقایسه اندازه تخمینی و واقعی جوامع
        /// </summary>
        public partial class SegmentSizeComparisonConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("مقایسه اندازه جوامع", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerSegment.Title), "عنوان جامعه");
                Sum(nameof(CustomerSegment.EstimatedSize), "تخمینی");
                Sum(nameof(CustomerSegment.ActualSize), "واقعی");
            }
        }

        /// <summary>
        /// گزارش نرخ رشد جوامع
        /// </summary>
        public partial class SegmentGrowthRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("نرخ رشد جوامع", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerSegment.Title), "عنوان جامعه");
                Average(nameof(CustomerSegment.GrowthRate), "نرخ رشد (%)");
                Sum(nameof(CustomerSegment.ActualSize), "تعداد فعلی");
            }
        }

        /// <summary>
        /// گزارش نرخ حفظ مشتریان جوامع
        /// </summary>
        public partial class SegmentRetentionRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("نرخ حفظ مشتریان جوامع", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerSegment.Title), "عنوان جامعه");
                Average(nameof(CustomerSegment.RetentionRate), "نرخ حفظ (%)");
                Sum(nameof(CustomerSegment.ActualSize), "تعداد اعضا");
            }
        }

        /// <summary>
        /// گزارش نرخ تعامل جوامع
        /// </summary>
        public partial class SegmentEngagementRateConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("نرخ تعامل جوامع", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerSegment.Title), "عنوان جامعه");
                Average(nameof(CustomerSegment.EngagementRate), "نرخ تعامل (%)");
                Sum(nameof(CustomerSegment.ActualSize), "تعداد اعضا");
            }
        }

        /// <summary>
        /// گزارش جوامع به تفکیک محدوده امتیاز عضویت
        /// </summary>
        public partial class SegmentsByMembershipScoreConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("جوامع بر اساس امتیاز عضویت", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(CustomerSegment.Title), "عنوان جامعه");
                DisplayColumn(nameof(CustomerSegment.MinMembershipScore), "حداقل امتیاز");
                DisplayColumn(nameof(CustomerSegment.MaxMembershipScore), "حداکثر امتیاز");
                DisplayColumn(nameof(CustomerSegment.ActualSize), "تعداد اعضا");
            }
        }

        /// <summary>
        /// گزارش آخرین محاسبه جوامع
        /// </summary>
        public partial class SegmentLastCalculationConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("آخرین محاسبه جوامع", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(CustomerSegment.Title), "عنوان جامعه");
                DisplayColumn(nameof(CustomerSegment.LastCalculationDate), "آخرین محاسبه");
                DisplayColumn(nameof(CustomerSegment.CalculationIntervalDays), "فاصله محاسبه (روز)");
                DisplayColumn(nameof(CustomerSegment.ActualSize), "تعداد فعلی");
            }
        }

        /// <summary>
        /// گزارش عملکرد کلی جوامع
        /// </summary>
        public partial class SegmentPerformanceOverviewConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(CustomerSegment.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("عملکرد کلی جوامع", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(CustomerSegment.Title), "عنوان جامعه");
                DisplayColumn(nameof(CustomerSegment.ActualSize), "تعداد اعضا");
                DisplayColumn(nameof(CustomerSegment.GrowthRate), "نرخ رشد");
                DisplayColumn(nameof(CustomerSegment.RetentionRate), "نرخ حفظ");
                DisplayColumn(nameof(CustomerSegment.EngagementRate), "نرخ تعامل");
            }
        }
    }
}
