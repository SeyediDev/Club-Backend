using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Question
{
    public int Id { get; set; }

    public string Question1 { get; set; } = null!;

    public string? Description { get; set; }

    public string Type { get; set; } = null!;

    public string? Items { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime? LastModifiedBy { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; } = new List<QuestionAnswer>();
}
