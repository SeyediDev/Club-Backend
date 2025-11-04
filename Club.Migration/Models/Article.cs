using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool? Active { get; set; }

    public string Link { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }
}
