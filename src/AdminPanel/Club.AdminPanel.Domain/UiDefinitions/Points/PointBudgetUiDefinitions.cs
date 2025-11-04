using Club.Domain.Entities.Points.Enums;

namespace Club.AdminPanel.Domain.UiDefinitions.Points;

public class PointBudgetUiDefinitions : SubCRUDDefinition<PointBudget>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(
            nameof(PointBudget.Point),
            nameof(PointBudget.Scope),
            nameof(PointBudget.CustomerSegment),
            nameof(PointBudget.Amount),
            nameof(PointBudget.Kind)
            );
        form.AddOrderBy(nameof(PointBudget.Point));
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(
            nameof(PointBudget.Point),
            nameof(PointBudget.Scope),
            nameof(PointBudget.CustomerSegment),
            nameof(PointBudget.FromDate),
            nameof(PointBudget.ToDate),
            nameof(PointBudget.Amount),
            nameof(PointBudget.Kind),
            nameof(PointBudget.EventChannel),
            nameof(PointBudget.EventType),
            nameof(PointBudget.PointLevel)
            );
    }
    
    protected override void UIRules(FormDefinition form)
    {
        form.ShowHide(nameof(PointBudget.Scope), 
            $"q[{nameof(PointBudget.Scope)}]=={(int)PointBudgetScope.PerCustomerSegment}", 
            nameof(PointBudget.CustomerSegment));
        form.FilterFormula(nameof(PointBudget.Point), 
            nameof(PointBudget.CustomerSegment), 
            $"({nameof(PointBudget.CustomerSegment)}.{nameof(CustomerSegment.TenantId)})==q[{nameof(PointBudget.Point)}.{nameof(Point.TenantId)}]");
        form.FilterFormula(nameof(PointBudget.Point), 
            nameof(PointBudget.PointLevel), 
            $"{nameof(PointLevel.PointId)}==q[{nameof(PointBudget.Point)}]");
    }

    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(
            nameof(PointBudget.Scope),
            nameof(PointBudget.CustomerSegment),
            nameof(PointBudget.Amount),
            nameof(PointBudget.Kind),
            nameof(PointBudget.FromDate),
            nameof(PointBudget.ToDate));
        form.AddOrderBy(nameof(PointBudget.Point));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(
            nameof(PointBudget.Scope),
            nameof(PointBudget.CustomerSegment),
            nameof(PointBudget.Amount),
            nameof(PointBudget.Kind),
            nameof(PointBudget.FromDate),
            nameof(PointBudget.ToDate),
            nameof(PointBudget.EventChannel),
            nameof(PointBudget.EventType),
            nameof(PointBudget.PointLevel)
            );
    }
}
