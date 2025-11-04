using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Device
{
    /// <summary>
    /// دستگاه ها
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// نوع
    /// </summary>
    public int ProductTypeId { get; set; }

    public string MacId { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual ICollection<UserAppDevice> UserAppDevices { get; set; } = new List<UserAppDevice>();
}
