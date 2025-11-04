using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class ProductType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? CheckDuration { get; set; }

    public bool IsService { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
