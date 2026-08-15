namespace Club.AdminPanel.Domain.UiDefinitions.Events;

public class EventTypeParameterUiDefinitions : SubCRUDDefinition<EventTypeParameter>
{
    public override string SubjectId => "Sub";
    public override void SubIndexViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(EventTypeParameter.Title),
                        nameof(EventTypeParameter.Key),
                        nameof(EventTypeParameter.IsOptional),
                        nameof(EventTypeParameter.CustomerParameter)
                        );
    }

    public override void SubViewModel(FormDefinition form)
    {
        form.AddFields(nameof(EventTypeParameter.Title),
                        nameof(EventTypeParameter.Key),
                        nameof(EventTypeParameter.IsOptional),
                        nameof(EventTypeParameter.CreatedBySystem),
                        nameof(EventTypeParameter.CustomerParameter)
                        );
    }
}
