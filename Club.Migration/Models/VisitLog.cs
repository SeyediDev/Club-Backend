using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VisitLog
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? Createdate { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime? LastModifiedBy { get; set; }

    public virtual VisitRequest Request { get; set; } = null!;
}
