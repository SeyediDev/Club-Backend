namespace Club.Domain.Entities.Customers.Views;

/// <summary>
/// ویو گزارشات مشتری - ترکیب اطلاعات مشتری با سازمان
/// </summary>
[DontAudit]
[View(@"SELECT c.*, 
ct.TenantId,
t.Title AS TenantTitle
FROM Customers.Customers c
LEFT JOIN Customers.CustomerTenants ct ON ct.CustomerId = c.Id AND ct.IsActive = 1
LEFT JOIN Customers.Tenants t ON t.Id = ct.TenantId", true)]
[DisplayName("گزارش مشتری")]
public class CustomerReportView : Customer
{
    /// <summary>
    /// شناسه سازمان بهره‌بردار
    /// </summary>
    [DisplayName("شناسه سازمان")]
    public int TenantId { get; set; }

    /// <summary>
    /// عنوان سازمان بهره‌بردار
    /// </summary>
    [DisplayName("عنوان سازمان")]
    [InDisplayString]
    [MaxLength(41)]
    public string? TenantTitle { get; set; }
}

