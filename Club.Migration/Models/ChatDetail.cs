using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class ChatDetail
{
    public long Id { get; set; }

    public long ChatId { get; set; }

    public int? UserId { get; set; }

    public string? Text { get; set; }

    public string? Content { get; set; }

    public bool IsDoctor { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual User? User { get; set; }
}
