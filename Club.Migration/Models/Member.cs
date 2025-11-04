using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Member
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long? Mobile { get; set; }

    public long? NationalCode { get; set; }

    public DateOnly BirthDate { get; set; }

    public byte GenderTypeId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual GenderType GenderType { get; set; } = null!;

    public virtual ICollection<QuestionAnswer1> QuestionAnswer1s { get; set; } = new List<QuestionAnswer1>();

    public virtual ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();
}
