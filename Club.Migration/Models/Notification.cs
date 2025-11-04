using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AppId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool IsRead { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Type App { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
