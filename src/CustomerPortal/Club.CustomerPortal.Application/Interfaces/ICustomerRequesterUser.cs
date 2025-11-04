namespace Club.CustomerPortal.Application.Interfaces;

/// <summary>
/// اطلاعات کاربر درخواست‌کننده در پرتال مشتریان
/// </summary>
public interface ICustomerRequesterUser
{
    /// <summary>
    /// شناسه مشتری لاگین شده
    /// </summary>
    int CustomerId { get; }

    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    string? Mobile { get; }

    /// <summary>
    /// شناسه Tenant
    /// </summary>
    string? TenantId { get; }
}
