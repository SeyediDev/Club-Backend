using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class QuestionAnswer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? MemberId { get; set; }

    public int QuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? LastModifiedBy { get; set; }

    public DateTime LastModified { get; set; }

    public virtual Question Question { get; set; } = null!;
}
