using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Product
{
    public int Id { get; set; }

    public int ProductTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public bool Active { get; set; }

    public string? SiteLink { get; set; }

    public string? CatalogueLink { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;
}
