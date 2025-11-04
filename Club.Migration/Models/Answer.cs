using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Answer
{
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public string Value { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Question1 Question { get; set; } = null!;

    public virtual ICollection<QuestionAnswer1> QuestionAnswer1s { get; set; } = new List<QuestionAnswer1>();
}
