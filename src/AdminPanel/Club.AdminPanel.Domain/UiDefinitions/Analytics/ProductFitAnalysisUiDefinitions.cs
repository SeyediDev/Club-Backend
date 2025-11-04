using Club.Domain.Entities.Analytics;

public class ProductFitAnalysisDefinitions : CRUDDefinition<ProductFitAnalysis>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(ProductFitAnalysis.Title),
                        nameof(ProductFitAnalysis.Tenant),
                        nameof(ProductFitAnalysis.AnalysisDate),
                        nameof(ProductFitAnalysis.ProductMarketFitScore),
                        nameof(ProductFitAnalysis.ProductServiceFitScore),
                        nameof(ProductFitAnalysis.ValueScore),
                        nameof(ProductFitAnalysis.CustomerSatisfactionScore),
                        nameof(ProductFitAnalysis.NetPromoterScore),
                        nameof(ProductFitAnalysis.CustomerSatisfactionRating),
                        nameof(ProductFitAnalysis.ProductQualityScore),
                        nameof(ProductFitAnalysis.ProductPerformanceScore)
                        );
    }

    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(ProductFitAnalysis.Tenant),
                       nameof(ProductFitAnalysis.Title),
                       nameof(ProductFitAnalysis.AnalysisDate),
                       nameof(ProductFitAnalysis.ProductMarketFitScore),
                       nameof(ProductFitAnalysis.ProductServiceFitScore),
                       nameof(ProductFitAnalysis.UniqueValueProposition),
                       nameof(ProductFitAnalysis.UniqueSellingProposition),
                       nameof(ProductFitAnalysis.ValueScore),
                       nameof(ProductFitAnalysis.CustomerSatisfactionScore),
                       nameof(ProductFitAnalysis.NetPromoterScore),
                       nameof(ProductFitAnalysis.CustomerSatisfactionRating),
                       nameof(ProductFitAnalysis.ProductQualityScore),
                       nameof(ProductFitAnalysis.ProductPerformanceScore),
                       nameof(ProductFitAnalysis.LastUpdatedDate),
                       nameof(ProductFitAnalysis.ModelVersion),
                       nameof(ProductFitAnalysis.AdditionalData)
                       );
    }
}
