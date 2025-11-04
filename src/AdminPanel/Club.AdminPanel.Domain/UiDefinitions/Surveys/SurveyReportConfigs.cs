using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;
using Club.Domain.Entities.Surveys;

namespace Club.AdminPanel.Domain.UiDefinitions.Surveys;

public partial class SurveyUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// نظرسنجی‌های فعال
        /// </summary>
        public partial class ActiveSurveysConfig : ReportConfigDefinition
        {
            protected override void Identify()
            {
                DefineConfig("نظرسنجی‌های فعال", ReportViewType.List);
            }

            protected override string WhereCondition => $"{nameof(Survey.IsActive)} == true";

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Survey.Title));
                DisplayColumn(nameof(Survey.SurveyType));
                DisplayColumn(nameof(Survey.StartDate));
                DisplayColumn(nameof(Survey.EndDate));
                DisplayColumn(nameof(Survey.TotalParticipants));
                DisplayColumn(nameof(Survey.ParticipationPoints));
            }
        }

        /// <summary>
        /// نظرسنجی‌های محبوب (بر اساس تعداد شرکت‌کنندگان)
        /// </summary>
        public partial class TopSurveysConfig : ReportConfigDefinition
        {
            protected override void Identify()
            {
                DefineConfig("نظرسنجی‌های محبوب", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Survey.Title));
                DisplayColumn(nameof(Survey.SurveyType));
                DisplayColumn(nameof(Survey.TotalParticipants));
                DisplayColumn(nameof(Survey.ParticipationPoints));
            }

            protected override void DefineOrderBy()
            {
                OrderByDesc(nameof(Survey.TotalParticipants));
            }
        }

        /// <summary>
        /// توزیع نظرسنجی‌ها بر اساس نوع
        /// </summary>
        public partial class SurveyTypeDistributionConfig : ReportConfigDefinition
        {
            protected override void Identify()
            {
                DefineConfig("توزیع بر اساس نوع", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Survey.SurveyType));
                Count();
            }
        }

        /// <summary>
        /// میزان مشارکت در نظرسنجی‌ها در طول زمان
        /// </summary>
        public partial class SurveyParticipationTrendConfig : ReportConfigDefinition
        {
            protected override void Identify()
            {
                DefineConfig("روند مشارکت در نظرسنجی‌ها", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Survey.CreateDate));
                Count();
            }
        }

        /// <summary>
        /// نظرسنجی‌های بر اساس محصول
        /// </summary>
        public partial class SurveysByProductConfig : ReportConfigDefinition
        {
            protected override void Identify()
            {
                DefineConfig("نظرسنجی‌ها بر اساس محصول", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Survey.Product));
                Count();
            }
        }

        /// <summary>
        /// میانگین مشارکت در نظرسنجی‌ها
        /// </summary>
        public partial class AverageParticipationConfig : ReportConfigDefinition
        {
            protected override void Identify()
            {
                DefineConfig("میانگین مشارکت", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Average(nameof(Survey.TotalParticipants));
            }
        }
    }
}
