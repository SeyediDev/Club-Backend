namespace Club.Migration.Models;

public partial class Exam
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? MemberId { get; set; }

    public int? UserDeviceId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Member? Member { get; set; }

    public virtual UserAppDevice? UserDevice { get; set; }

    public virtual ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
}
