using Neo.Bpms.Domain.Entities.Cmmn;
using Neo.Bpms.Domain.Entities.Cmmn.Entities;
using Neo.Bpms.Domain.Entities.Cmmn.Fields;
using Neo.Bpms.Domain.Expressions.Model.ExpressionNodes;
using Neo.Bpms.Domain.Expressions.Parsers;
using Neo.Bpms.Domain.Modeling.MetaDefinitions.ProjectDefinitions;
using Neo.Bpms.Infrastructure.Features.Cmmn.Dashboards;
using Neo.Bpms.Infrastructure.Features.Cmmn.Forms;
using Neo.Bpms.Infrastructure.Features.Cmmn.Reports;
using Neo.Bpms.Infrastructure.Features.SystemConfigs;
using Neo.Bpms.UI.MVC.Controllers;
using Neo.Bpms.UI.MVC.Controllers.Public;
using Neo.Bpms.UI.MVC.Features;
using Neo.Common.Extensions;
using Neo.Domain.Entities.Base;
using Neo.Domain.Repository;
using Club.Domain.Repository;
using Microsoft.Extensions.Options;
using static Neo.Bpms.Domain.Entities.Cmmn.AutoCalc;

namespace Club.AdminPanel.Web.Controllers;

public class HomeController : DesktopController
{
    private static bool IsFirst = true;
    public HomeController(IClubUnitOfWorkCommand commandClubUnitOfWork, ILogger<HomeController> logger,
        DashboardStructRoutines dashboardStructRoutines, DashboardConfigManager dashboardConfigManager,
        FormStructRoutines formStructRoutines, ControllerMethods controllerMethods,
        ReportConfigManager reportConfigManager, 
        FilterConfigBackupRestore filterConfigBackupRestore, 
        FilterManager filterController, IOptions<CmmnSettings> cmmnSettings) :
        base(dashboardStructRoutines,
            dashboardConfigManager,
            formStructRoutines,
            controllerMethods,  
            reportConfigManager,
            filterConfigBackupRestore,
            filterController, cmmnSettings)
    {
        DashboardStructRoutines = dashboardStructRoutines;
        if (IsFirst)
        {
            UpdateModelMapping(commandClubUnitOfWork, logger);
            IsFirst = false;
        }
    }

    private static void UpdateModelMapping(IClubUnitOfWorkCommand commandClubUnitOfWork, ILogger<HomeController> logger)
    {
        foreach (Entity entity in ProjectDefinition.Project.Entities.Values)
        {
            if (entity.Provider is not nameof(DomainProvider.Domain))
            {
                entity.Provider = nameof(DomainProvider.Domain);
            }
            if (entity.EntityType is not null && ReflectionTools.IsInBaseInterface<IDomainEventEntity>(entity.EntityType))
                UpdateModelMapping(commandClubUnitOfWork, logger, entity);
        }
    }

    private static void UpdateModelMapping(IClubUnitOfWorkCommand commandClubUnitOfWork, ILogger<HomeController> logger, Entity entity)
    {
        if (entity.NotMapped)
        {
            return;
        }
        EntityTableInfo tableInfo = commandClubUnitOfWork.GetEntityTableInfo(entity.EntityType);
        if (tableInfo == null)
        {
            return;
        }
        if (tableInfo.Schema is not null && entity.Schema is null)
        {
            entity.Schema = tableInfo.Schema;
        }
        entity.DbTableNameMap = tableInfo.TableName;
        foreach (EntityFieldColumnInfo pkInfo in tableInfo.PrimaryKeys)
        {
            EntityField entityField = entity.GetField(pkInfo.Id);
            if (entityField == null)
            {
                logger.LogError("In class {className} Have pk {pk} that not exists in class", entity.Id, pkInfo.Id);
                continue;
            }
            EntityField keyField = entity.KeyFields.FirstOrDefault(k => k.Id == pkInfo.Id);
            if (keyField == null)
            {
                logger.LogError("In class {className} Have pk {pk} that not map in class", entity.Id, pkInfo.Id);
                continue;
            }
            if (pkInfo.IsIdentity)
            {
                entity.InitAutoCalcs();
                ExpressionTree formulaEx = Parser.ParseTree("AutoIncrement()");
                entity.AutoCalcs.AddAutoCalc(new AutoCalc
                {
                    FieldId = pkInfo.Id,
                    GenerationType = AutoCalc.eGenerationType.DBInsert,
                    Formula = formulaEx,
                    Condition = null,
                    Loaction = AutoCalcLocation.BeforeValidation,
                    IfNull = false,
                    RecalcOnAnyChange = false,
                });
            }
        }
        foreach (EntityField entityField in entity.entityFields.Values)
        {
            if (entityField.NotMapped || entityField.NotMap)
            {
                continue;
            }
            if (tableInfo.Properties.TryGetValue(entityField.Id, out EntityFieldColumnInfo fieldInfo) && fieldInfo != null)
            {
                if (fieldInfo.Name is not null)
                {
                    entityField.DbFieldName = fieldInfo.Name;
                }
                if (fieldInfo.Comment is not null)
                {
                    entityField.Name = fieldInfo.Comment;
                }
            }
            else
            {
                logger.LogError("In class {className} Have field Id {entityField} that not map in db", entity.Id, entityField.Id);
            }
        }
        foreach (EntityFieldColumnInfo fieldInfo in tableInfo.Properties.Values)
        {
            if (entity.entityFields.TryGetValue(fieldInfo.Id, out EntityField entityField)&& entityField is null)
            {
                logger.LogError("In class {className} Have db column {column} that not exists in class ", entity.Id, fieldInfo.Id);
            }
        }
    }

    public DashboardStructRoutines DashboardStructRoutines { get; }
}
