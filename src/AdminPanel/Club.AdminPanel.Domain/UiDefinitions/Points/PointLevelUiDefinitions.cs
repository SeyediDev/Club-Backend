namespace Club.AdminPanel.Domain.UiDefinitions.Points;

public class PointLevelUiDefinitions : SubCRUDDefinition<PointLevel>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(PointLevel.Title),
            nameof(PointLevel.Point),
            nameof(PointLevel.Level),
            nameof(PointLevel.MinXp),
            nameof(PointLevel.MaxXp)
            );
        form.AddOrderBy(nameof(PointLevel.Point));
        form.AddOrderBy(nameof(PointLevel.Level));
    }

    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(
            nameof(PointLevel.Title),
            nameof(PointLevel.Point),
            nameof(PointLevel.Level),
            nameof(PointLevel.MinXp),
            nameof(PointLevel.MaxXp)
            );
    }
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(PointLevel.Title),
            nameof(PointLevel.Point),
            nameof(PointLevel.Level),
            nameof(PointLevel.MinXp),
            nameof(PointLevel.MaxXp)
            );
        
        form.AddOrderBy(nameof(PointLevel.Point));
        form.AddOrderBy(nameof(PointLevel.Level));
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(
            nameof(PointLevel.Title),
            nameof(PointLevel.Point),
            nameof(PointLevel.Level),
            nameof(PointLevel.MinXp),
            nameof(PointLevel.MaxXp)
            );
    }
}
