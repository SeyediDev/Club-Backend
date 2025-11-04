namespace Club.Domain.Entities.Points.Enums;

public enum PointBudgetScope
{
    [Description("کل مشتریان سازمان بهره‌بردار")]
    PerTenant = 1,
    [Description("هر مشتری")]
    PerCustomer = 2,
    [Description("مشتریان یک جامعه")]
    PerCustomerSegment = 3,
}
