using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Settlement
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public long Amount { get; set; }

    public int StatusId { get; set; }

    public DateTime? PayDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual User User { get; set; } = null!;
}
