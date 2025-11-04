namespace Club.AdminPanel.Domain.UiDefinitions.Points;

public class PointConversionRateUiDefinitions : SubCRUDDefinition<PointConversionRate>
{
    public override string SubjectId => "Sub";

    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(PointConversionRate.FromPoint),
                        nameof(PointConversionRate.ToPoint),
                        nameof(PointConversionRate.ConversionRate),
                        nameof(PointConversionRate.CommissionPoint),
                        nameof(PointConversionRate.CommissionAmount),
                        nameof(PointConversionRate.IsActive)
                        );
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(PointConversionRate.FromPoint),
                       nameof(PointConversionRate.ToPoint),
                       nameof(PointConversionRate.ConversionRate),
                       nameof(PointConversionRate.CommissionPoint),
                       nameof(PointConversionRate.CommissionAmount),
                       nameof(PointConversionRate.IsActive)
                       );
    }
}

