using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class PlanDetail
{
    public int Id { get; set; }

    public int PlanId { get; set; }

    public string Feature { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Plan Plan { get; set; } = null!;
}
