using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VisitRequest
{
    public int Id { get; set; }

    public int UserAppId { get; set; }

    public int? MemberId { get; set; }

    public int UserDoctorId { get; set; }

    public int ExamId { get; set; }

    public DateTime Date { get; set; }

    public int ActivityServiceId { get; set; }

    public int? StatusId { get; set; }

    public decimal? Rating { get; set; }

    public string? Review { get; set; }

    public int? ExamResultId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual Exam Exam { get; set; } = null!;

    public virtual ExamResult? ExamResult { get; set; }

    public virtual Member? Member { get; set; }

    public virtual UserApp UserApp { get; set; } = null!;

    public virtual UserDoctor UserDoctor { get; set; } = null!;

    public virtual ICollection<VisitLog> VisitLogs { get; set; } = new List<VisitLog>();
}
