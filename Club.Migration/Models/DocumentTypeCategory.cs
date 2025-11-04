using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class DocumentTypeCategory
{
    public int Id { get; set; }

    public int DocumentTypeId { get; set; }

    public string Category { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;
}
