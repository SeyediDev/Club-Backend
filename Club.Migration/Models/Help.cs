using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Help
{
    public int Id { get; set; }

    public int AppId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Type App { get; set; } = null!;
}
