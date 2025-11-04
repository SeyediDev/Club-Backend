using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Plan
{
    /// <summary>
    /// اشتراک
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// عنوان اشتراک
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// تعداد روز
    /// </summary>
    public byte ValidDays { get; set; }

    public byte CardiologistInterpretation { get; set; }

    public byte? Aiinterpretation { get; set; }

    /// <summary>
    /// تعداد بیمار
    /// </summary>
    public byte MemberCount { get; set; }

    /// <summary>
    /// هزینه اشتراک
    /// </summary>
    public int BasePrice { get; set; }

    /// <summary>
    /// هزینه اشتراک
    /// </summary>
    public int Price { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<PlanDetail> PlanDetails { get; set; } = new List<PlanDetail>();

    public virtual ICollection<UserPlan> UserPlans { get; set; } = new List<UserPlan>();
}
