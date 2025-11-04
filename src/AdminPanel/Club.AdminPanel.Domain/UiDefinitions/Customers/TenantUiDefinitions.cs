using Club.Domain.Entities.Rewards;

namespace Club.AdminPanel.Domain.UiDefinitions.Customers;

public class TenantDefinitions : CRUDDefinition<Tenant>
{
    protected override void IndexFormViewModel(FormDefinition form)
    {
        form.AddColumns(nameof(Tenant.Title),
                       nameof(Tenant.ApiKey),
                       nameof(Tenant.CreateDate),
                       nameof(Tenant.CreatedBy)
                       );
    }
    
    protected override void CUDFormsViewModel(CUDForm form)
    {
        form.AddFields(nameof(Tenant.Title),
                       nameof(Tenant.ApiKey),
                       nameof(Tenant.CreateDate),
                       nameof(Tenant.CreatedBy)
                       );
    }
    protected override void EditFormSubTables(CUDForm form)
    {
        eControlTypeId groupControlType = eControlTypeId.None;
        form.AddSubTable(nameof(Point), nameof(Point.Tenant), null/*"SubTenant"*/,
            "امتیازات تعریف شده", null, false, groupControlType);
        form.AddSubTable(nameof(Reward), nameof(Reward.Tenant), null/*"SubTenant"*/,
            "پاداش‌های تعریف شده", null, false, groupControlType);
        form.AddSubTable(nameof(CustomerParameter), nameof(CustomerParameter.Tenant), null/*"SubTenant"*/,
            "پارامترهای مشتری", null, true, groupControlType);
        form.AddSubTable(nameof(Promotion), nameof(Promotion.Tenant), null/*"SubTenant"*/,
            "پویش ها", null, false, groupControlType);
        form.AddSubTable(nameof(ScoringRule), nameof(ScoringRule.Tenant), null/*"SubTenant"*/,
            "قوانین امتیازدهی", null, false, groupControlType);
    }
}
