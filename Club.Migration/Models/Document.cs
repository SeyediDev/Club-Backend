using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Document
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? MemberId { get; set; }

    public int? DocumentTypeId { get; set; }

    public string? Checksum { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public long? SubjectId { get; set; }

    public string? SubjectTitle { get; set; }

    public string? SubjectField { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Member? Member { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserApp> UserApps { get; set; } = new List<UserApp>();

    public virtual ICollection<UserDoctor> UserDoctors { get; set; } = new List<UserDoctor>();
}
