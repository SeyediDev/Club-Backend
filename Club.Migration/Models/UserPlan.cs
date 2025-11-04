using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class UserPlan
{
    /// <summary>
    /// تاریخچه خرید اشتراک
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// کاربر
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// اشتراک
    /// </summary>
    public int PlanId { get; set; }

    /// <summary>
    /// تعداد بیمار
    /// </summary>
    public byte MemberCount { get; set; }

    /// <summary>
    /// زمان شروع
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// زمان پایان
    /// </summary>
    public DateTime EndDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastModifiedBy { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime? CreatedBy { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Plan Plan { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
