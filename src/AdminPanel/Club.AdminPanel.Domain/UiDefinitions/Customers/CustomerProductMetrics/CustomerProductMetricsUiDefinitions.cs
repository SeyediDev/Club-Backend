namespace Club.AdminPanel.Domain.UiDefinitions.Customers.CustomerProductMetrics;

public class CustomerProductMetricsUiDefinitions : CRUDDefinition<Club.Domain.Entities.Metrics.Data.CustomerProductMetrics>
{
    private static readonly List<string> DefaultRoles =
    [
        Neo.Domain.Constants.Roles.Admin,
        ClubRoles.Manager,
        ClubRoles.Analyst,
        ClubRoles.MarketingManager
    ];

    public override List<string>? Roles => DefaultRoles;

    protected override void IndexFormViewModel()
    {
        AddColumns(
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerLifetimeValue),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerAcquisitionCost),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RetentionRate),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RepeatPurchaseRate),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.NextPurchaseProbability),
            nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LastPurchaseDate)
        );

        form.AddOrderBy(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenantId));
        AddSubjectColumn<FinancialMetrics>();
        AddSubjectColumn<PurchaseMetrics>();
        AddSubjectColumn<EngagementMetrics>();
        AddSubjectColumn<PredictiveMetrics>();
    }

    protected override void CUDFormsViewModel()
    {
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product));

        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerLifetimeValue));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerAcquisitionCost));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PaybackPeriodDays));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin));

        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.AverageOrderValue));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseFrequency));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.AverageTimeBetweenPurchasesDays));

        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RetentionRate));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RepeatPurchaseRate));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.SatisfactionScore));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.EngagementScore));

        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.NextPurchaseProbability));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PredictedNextPurchaseDate));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PredictedNextPurchaseValue));
        AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LastMetricsUpdateDate));
    }

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        public override List<string>? Roles => DefaultRoles;

        /// <summary>
        /// ماتریس سودآوری مشتری × محصول
        /// </summary>
        public class CustomerProductProfitabilityMatrixConfig() : GroupByConfigDefinition
        {
            protected override List<string> Roles => DefaultRoles;
            protected override string Name => "ماتریس سودآوری مشتری × محصول";
            protected override GroupByViewType GroupByViewType => GroupByViewType.Matrix;

            protected override void DefineGroupBy()
            {
                GroupByFormula($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant)}.{nameof(CustomerTenant.Customer)}", "مشتری", addAsDisplayColumn: false);
                LayoutColumn(false, $"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant)}.{nameof(CustomerTenant.Customer)}", ConfiguredReport.ReportMatrixType.Vertical);
                DisplayColumn($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant)}.{nameof(CustomerTenant.Customer)}", "مشتری");

                GroupByFormula($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product)}.{nameof(Product.Title)}", "محصول", addAsDisplayColumn: false);
                LayoutColumn(false, $"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product)}.{nameof(Product.Title)}", ConfiguredReport.ReportMatrixType.Horizontal);
                DisplayColumn($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product)}.{nameof(Product.Title)}", "محصول");

                SumFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount), "تعداد خرید");
                SumFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue), "مجموع درآمد");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio), "میانگین LTV:CAC");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin), "میانگین حاشیه سود");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RetentionRate), "میانگین نرخ حفظ");
            }

            protected override void DefineSubReports()
            {
                AddSubReport<CustomerProductProfitabilityDetailsConfig>();
            }
        }

        public class CustomerProductProfitabilityDetailsConfig() : ReportConfigDefinition
        {
            protected override List<string> Roles => DefaultRoles;
            protected override string Name => "جزئیات سودآوری مشتری-محصول";

            protected override void DefineColumns()
            {
                DisplayColumn($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant)}.{nameof(CustomerTenant.Customer)}", "مشتری");
                DisplayColumn($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product)}.{nameof(Product.Title)}", "محصول");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount), "تعداد خرید");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue), "مجموع درآمد");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerLifetimeValue), "CLV");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerAcquisitionCost), "CAC");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio), "LTV:CAC");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin), "حاشیه سود");
                DisplayColumn(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LastPurchaseDate), "آخرین خرید");
            }
        }

        public class TopProductsByCustomerConfig() : GroupByConfigDefinition
        {
            protected override List<string> Roles => DefaultRoles;
            protected override string Name => "محصولات برتر هر مشتری";

            protected override void DefineGroupBy()
            {
                GroupByFormula($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant)}.{nameof(CustomerTenant.Customer)}", "مشتری");
                GroupByFormula($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product)}.{nameof(Product.Title)}", "محصول");
                SumFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue), "مجموع درآمد");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio), "میانگین LTV:CAC");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin), "میانگین حاشیه سود");
                Count(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount), "تعداد خرید");
            }
        }

        public class TopCustomersByProductConfig() : GroupByConfigDefinition
        {
            protected override List<string> Roles => DefaultRoles;
            protected override string Name => "مشتریان برتر هر محصول";

            protected override void DefineGroupBy()
            {
                GroupByFormula($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product)}.{nameof(Product.Title)}", "محصول");
                GroupByFormula($"{nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant)}.{nameof(CustomerTenant.Customer)}", "مشتری");
                SumFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue), "مجموع درآمد");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio), "میانگین LTV:CAC");
                AverageFormula(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin), "میانگین حاشیه سود");
                Count(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount), "تعداد خرید");
            }
        }
    }

    public class FinancialMetrics : SubjectEditForm2<FinancialMetrics>
    {
        public override string Name => "معیارهای مالی";
        public override List<string>? Roles => DefaultRoles;

        protected override void ViewModel()
        {
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerLifetimeValue));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerAcquisitionCost));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LtvToCacRatio));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PaybackPeriodDays));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerProfitMargin));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.ReferralValue));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.TotalRevenue));
        }
    }

    public class PurchaseMetrics : SubjectEditForm2<PurchaseMetrics>
    {
        public override string Name => "معیارهای خرید";
        public override List<string>? Roles => DefaultRoles;

        protected override void ViewModel()
        {
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseCount));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.AverageOrderValue));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PurchaseFrequency));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.AverageTimeBetweenPurchasesDays));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.FirstPurchaseDate));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LastPurchaseDate));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.DaysSinceLastPurchase));
        }
    }

    public class EngagementMetrics : SubjectEditForm2<EngagementMetrics>
    {
        public override string Name => "تعامل و وفاداری";
        public override List<string>? Roles => DefaultRoles;

        protected override void ViewModel()
        {
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RetentionRate));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.RepeatPurchaseRate));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.SatisfactionScore));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.EngagementScore));
        }
    }

    public class PredictiveMetrics : SubjectEditForm2<PredictiveMetrics>
    {
        public override string Name => "پیش‌بینی";
        public override List<string>? Roles => DefaultRoles;

        protected override void ViewModel()
        {
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.CustomerTenant), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.Product), eControlPropertyId.ReadOnly);
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.NextPurchaseProbability));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PredictedNextPurchaseDate));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.PredictedNextPurchaseValue));
            AddField(nameof(Club.Domain.Entities.Metrics.Data.CustomerProductMetrics.LastMetricsUpdateDate));
        }
    }
}