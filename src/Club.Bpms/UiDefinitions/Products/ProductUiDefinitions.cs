using Neo.Bpms.Domain.Entities.Cmmn.UI.Reports;

namespace Club.Bpms.UiDefinitions.Products;

public partial class ProductUiDefinitions : CRUDDefinition<Product>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Product.Title),
                        nameof(Product.ProductType),
                        nameof(Product.Price),
                        nameof(Product.PointsEarnable),
                        nameof(Product.Tenant),
                        nameof(Product.IsActive),
                        nameof(Product.PurchaseCount),
                        nameof(Product.TotalRevenue)
                        );
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Product.Title),
                       nameof(Product.Key),
                       nameof(Product.Description),
                       nameof(Product.ProductType),
                       nameof(Product.Tenant),
                       nameof(Product.Price),
                       nameof(Product.PointsEarnable),
                       nameof(Product.IsActive),
                       nameof(Product.ExpectedConsumptionDuration),
                       nameof(Product.TypicalUsageFrequency),
                       nameof(Product.AveragePurchaseCycle),
                       nameof(Product.ReorderThreshold),
                       nameof(Product.CustomerLifetimeValueProduct),
                       nameof(Product.TypicalCustomerLifetime),
                       nameof(Product.AveragePurchasesPerCustomerLifetime),
                       nameof(Product.RepeatPurchaseRate)
                       );
        // Add Picture field as File control
        form.AddField(nameof(Product.Picture), eControlTypeId.File);
    }

    // =====================================================
    // Public Reports
    // =====================================================

    public new partial class PublicReport : CRUDDefinition.PublicReport
    {
        /// <summary>
        /// گزارش محصولات فعال
        /// </summary>
        public partial class ActiveProductsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Product.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("محصولات فعال", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Product.Title), "عنوان");
                DisplayColumn(nameof(Product.ProductType), "نوع");
                DisplayColumn(nameof(Product.Price), "قیمت");
                DisplayColumn(nameof(Product.PointsEarnable), "امتیاز قابل کسب");
                DisplayColumn(nameof(Product.PurchaseCount), "تعداد خرید");
                OrderByDesc(nameof(Product.PurchaseCount));
            }
        }

        /// <summary>
        /// گزارش محبوب‌ترین محصولات
        /// </summary>
        public partial class PopularProductsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override string WhereCondition => $"{nameof(Product.IsActive)} == true";
            
            protected override void Identify()
            {
                DefineConfig("محبوب‌ترین محصولات", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Product.Title), "محصول");
                Sum(nameof(Product.PurchaseCount), "تعداد خرید");
                Average(nameof(Product.Price), "میانگین قیمت");
                OrderByDesc("SUM");
            }
        }

        /// <summary>
        /// گزارش محصولات به تفکیک سازمان
        /// </summary>
        public partial class ProductsByCategoryConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("محصولات به تفکیک سازمان", ReportViewType.Chart, Report.ChartType.Pie);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Product.Tenant), "سازمان");
                Count(null, "تعداد");
            }
        }

        /// <summary>
        /// گزارش محصولات به تفکیک نوع (محصول)
        /// </summary>
        public partial class ProductsByTypeConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            
            protected override void Identify()
            {
                DefineConfig("محصولات به تفکیک نوع", ReportViewType.Chart, Report.ChartType.Bar);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Product.ProductType), "نوع");
                Count(null, "تعداد");
                Sum(nameof(Product.PurchaseCount), "کل خریدها");
            }
        }

        /// <summary>
        /// گزارش محصولات به تفکیک سازمان
        /// </summary>
        public partial class ProductsByTenantConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            
            protected override void Identify()
            {
                DefineConfig("محصولات به تفکیک سازمان", ReportViewType.GroupByList);
            }

            protected override void DefineColumns()
            {
                GroupBy(nameof(Product.Tenant), "سازمان");
                Count(null, "تعداد محصولات");
                Sum(nameof(Product.PurchaseCount), "کل خریدها");
                OrderByDesc("SUM");
            }
        }

        /// <summary>
        /// گزارش محصولات با بیشترین امتیاز
        /// </summary>
        public partial class HighPointProductsConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Manager]; }
            protected override string WhereCondition => $"{nameof(Product.IsActive)} == true AND {nameof(Product.PointsEarnable)} > 0";
            
            protected override void Identify()
            {
                DefineConfig("محصولات با بیشترین امتیاز", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Product.Title), "عنوان");
                DisplayColumn(nameof(Product.PointsEarnable), "امتیاز");
                DisplayColumn(nameof(Product.Price), "قیمت");
                DisplayColumn(nameof(Product.PurchaseCount), "تعداد خرید");
                OrderByDesc(nameof(Product.PointsEarnable));
            }
        }

        /// <summary>
        /// گزارش نرخ تکرار خرید محصولات
        /// </summary>
        public partial class ProductRepeatPurchaseConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override string WhereCondition => $"{nameof(Product.RepeatPurchaseRate)} > 0";
            
            protected override void Identify()
            {
                DefineConfig("نرخ تکرار خرید محصولات", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Product.Title), "محصول");
                DisplayColumn(nameof(Product.RepeatPurchaseRate), "نرخ تکرار خرید");
                DisplayColumn(nameof(Product.AveragePurchaseCycle), "چرخه خرید");
                DisplayColumn(nameof(Product.PurchaseCount), "تعداد خرید");
                OrderByDesc(nameof(Product.RepeatPurchaseRate));
            }
        }

        /// <summary>
        /// گزارش ارزش طول عمر مشتری برای محصولات
        /// </summary>
        public partial class ProductCLVConfig : ReportConfigDefinition
        {
            protected override List<string> Roles { get => [Neo.Domain.Constants.Roles.Admin, ClubRoles.Analyst]; }
            protected override string WhereCondition => $"{nameof(Product.CustomerLifetimeValueProduct)} > 0";
            
            protected override void Identify()
            {
                DefineConfig("ارزش طول عمر مشتری محصولات", ReportViewType.List);
            }

            protected override void DefineColumns()
            {
                DisplayColumn(nameof(Product.Title), "محصول");
                DisplayColumn(nameof(Product.CustomerLifetimeValueProduct), "CLV");
                DisplayColumn(nameof(Product.AveragePurchasesPerCustomerLifetime), "میانگین خرید");
                DisplayColumn(nameof(Product.TypicalCustomerLifetime), "طول عمر مشتری");
                OrderByDesc(nameof(Product.CustomerLifetimeValueProduct));
            }
        }
    }
}
