global using Neo.Bpms.Domain.Model.Project;
global using Neo.Bpms.Domain.Modeling.MetaDefinitions.Projects;
global using Neo.Bpms.MetaModel.ProcessData;
global using Club.AdminPanel.Domain.Domain.Club;
using Neo.Bpms.Domain.Modeling.UiDefinitions;

namespace Club.AdminPanel.Domain;

public class ClubProjectDefinition : ProjectMetaDefinition
{
    public override ProjectContext Identify()
    {
        return DefineProject(
             customerName: "پلتفرم باشگاه مشتریان",
             projectName: "پلتفرم باشگاه مشتریان",
             projectCode: "580614",
             startDate: "1404/06/05",
             supportStartDate: "",
             fileMethod: "FileSystem",
             hasDesignFeatures: true
        );
    }

    public override void DefineNamespaceNames()
    {
        _ = AddNamespace<CmmnNamespace>();
        _ = AddNamespace<CmmnConfigNamespace>();
        _ = AddNamespace<ProcessModelNamespace>();
        _ = AddNamespace<ProcessDataNamespace>();

        AddNamespace<ClubNamespace>();
    }

    public override void DefineBPMNDefinitions()
    {
        //DefineBpmnDefinitions<ClubDefinitions>();
    }
}
