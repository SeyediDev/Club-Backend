using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class FieldDegree
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Field> Fields { get; set; } = new List<Field>();
}
