using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Activity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int WeekDay { get; set; }

    public TimeOnly FromTime { get; set; }

    public TimeOnly ToTime { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<ActivityService> ActivityServices { get; set; } = new List<ActivityService>();

    public virtual User User { get; set; } = null!;
}
