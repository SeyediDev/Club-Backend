using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class UserAppDevice
{
    /// <summary>
    /// دستگاه های تخصیص یافته
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// دستگاه
    /// </summary>
    public int DeviceId { get; set; }

    /// <summary>
    /// کاربر
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// تاریخ شروع به کار
    /// </summary>
    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual User User { get; set; } = null!;
}
