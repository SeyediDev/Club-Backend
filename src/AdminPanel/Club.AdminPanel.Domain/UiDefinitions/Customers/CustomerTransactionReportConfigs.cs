using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.AdminPanel.Domain.UiDefinitions.Customers;

public partial class CustomerTransactionUiDefinitions
{
    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        // =====================================================
        // Transaction Analytics Reports
        // =====================================================

        /// <summary>
        /// گزارش تراکنش‌ها به تفکیک ماه
        /// </summary>
        public partial class TransactionsByMonthConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("تراکنش‌های ماهانه", ReportViewType.Chart, Report.ChartType.Line);
            }

            protected override void DefineColumns()
            {
                GroupBy("CreatedAtMonth", "ماه");
                Count(null, "تعداد تراکنش‌ها");
                Sum(nameof(CustomerTransaction.Credit), "مجموع بستانکار");
                Sum(nameof(CustomerTransaction.Debit), "مجموع بدهکار");
            }
        }

        /// <summary>
        /// گزارش توزیع تراکنش‌ها به تفکیک نوع
        /// </summary>
        public partial class TransactionsByTypeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("تراکنش‌ها به تفکیک نوع", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerTransaction.TransactionType), "نوع تراکنش");
                Count(null, "تعداد");
                Sum(nameof(CustomerTransaction.Balance), "مجموع مانده");
            }
        }

        /// <summary>
        /// گزارش بیشترین تراکنش‌ها به تفکیک مشتری
        /// </summary>
        public partial class TopCustomersByTransactionsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("مشتریان با بیشترین تراکنش", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerTransaction.CustomerId), "مشتری");
                Count(null, "تعداد تراکنش‌ها");
                Sum(nameof(CustomerTransaction.Credit), "مجموع اعتبار");
                Sum(nameof(CustomerTransaction.Debit), "مجموع برداشت");
                
                OrderByDesc("COUNT"); // نزولی - بیشترین تراکنش
            }
        }

        /// <summary>
        /// گزارش موجودی امتیازات مشتریان
        /// </summary>
        public partial class CustomerPointsBalanceConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("موجودی امتیازات مشتریان", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(CustomerTransaction.CustomerId), "مشتری");
                DisplayColumn(nameof(CustomerTransaction.Balance), "موجودی");
                DisplayColumn(nameof(CustomerTransaction.PointId), "نوع امتیاز");
            }
        }

        /// <summary>
        /// گزارش تراکنش‌های بازدید نشده
        /// </summary>
        public partial class UnvisitedTransactionsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(CustomerTransaction.VisitedAt)} == null";
            
            protected override void Identify()
            {
                DefineConfig("تراکنش‌های بازدید نشده", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(CustomerTransaction.CustomerId), "مشتری");
                DisplayColumn(nameof(CustomerTransaction.Credit), "اعتبار");
                DisplayColumn(nameof(CustomerTransaction.Debit), "برداشت");
                DisplayColumn(nameof(CustomerTransaction.Balance), "مانده");
                DisplayColumn(nameof(CustomerTransaction.CreateDate), "تاریخ ایجاد");
            }
        }

        /// <summary>
        /// گزارش میانگین ارزش تراکنش
        /// </summary>
        public partial class AverageTransactionValueConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("میانگین ارزش تراکنش", ReportViewType.Chart, Report.ChartType.MetricBox);
            }

            protected override void DefineColumns()
            {
                Average(nameof(CustomerTransaction.Credit), "میانگین اعتبار");
                Average(nameof(CustomerTransaction.Debit), "میانگین برداشت");
            }
        }

        /// <summary>
        /// گزارش تراکنش‌های مرتبط با قوانین امتیازدهی
        /// </summary>
        public partial class TransactionsByScoringRuleConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("تراکنش‌ها به تفکیک قانون امتیازدهی", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(CustomerTransaction.ScoringRuleId), "قانون امتیازدهی");
                Count(null, "تعداد تراکنش‌ها");
                Sum(nameof(CustomerTransaction.Credit), "مجموع امتیازات اعطا شده");
            }
        }
    }
}
