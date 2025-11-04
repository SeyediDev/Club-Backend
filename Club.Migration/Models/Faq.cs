using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Faq
{
    public int Id { get; set; }

    public int AppId { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int SortIndex { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Type App { get; set; } = null!;
}
