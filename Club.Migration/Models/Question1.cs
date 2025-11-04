using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Question1
{
    /// <summary>
    /// سوالات
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// شرح سوال
    /// </summary>
    public string Title { get; set; } = null!;

    public byte AnswerDataType { get; set; }

    public bool IsMultiple { get; set; }

    public bool SelectFromList { get; set; }

    public bool Mandatory { get; set; }

    public bool IsRequired { get; set; }

    public int Order { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<QuestionAnswer1> QuestionAnswer1s { get; set; } = new List<QuestionAnswer1>();

    //public virtual ICollection<QuestionDetail> QuestionDetails { get; set; } = new List<QuestionDetail>();
}
