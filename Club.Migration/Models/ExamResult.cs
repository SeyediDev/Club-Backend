using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class ExamResult
{
    public int Id { get; set; }

    public int ExamId { get; set; }

    public int ResultTypeId { get; set; }

    public string Result { get; set; } = null!;

    public int? FileId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public long? UserPlanId { get; set; }

    public virtual Exam Exam { get; set; } = null!;

    public virtual Document? File { get; set; }

    public virtual ExamResultType ResultType { get; set; } = null!;

    public virtual UserPlan? UserPlan { get; set; }

    public virtual ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
}
