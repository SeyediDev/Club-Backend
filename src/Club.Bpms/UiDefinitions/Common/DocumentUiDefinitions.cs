namespace Club.Bpms.UiDefinitions.Common;

public class DocumentUiDefinitions : CRUDDefinition
{
    public override Type DefinitionEntity => typeof(Document);
    protected override void IndexFormViewModel(FormDefinition form)
    {
        
        form.AddColumns(nameof(Document.DocumentType),
                        nameof(Document.SubjectTitle),
                        nameof(Document.SubjectId)
                        );
    }
}