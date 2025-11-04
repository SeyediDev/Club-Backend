using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class ActivityService
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public int ServiceTypeId { get; set; }

    public double Price { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual ServiceType ServiceType { get; set; } = null!;
}
