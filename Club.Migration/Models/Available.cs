using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Available
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }
}
