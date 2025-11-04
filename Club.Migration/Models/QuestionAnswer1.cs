using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class QuestionAnswer1
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? MemberId { get; set; }

    public int QuestionId { get; set; }

    public int? AnswerId { get; set; }

    public string? Value { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Answer? Answer { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Question1 Question { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
