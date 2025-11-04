using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class CultureTerm
{
    public int Id { get; set; }

    public int? AppId { get; set; }

    public int LanguageId { get; set; }

    public string SubjectField { get; set; } = null!;

    public int SubjectId { get; set; }

    public string SubjectTitle { get; set; } = null!;

    public string Term { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Type? App { get; set; }

    public virtual Language Language { get; set; } = null!;
}
