using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Reminder
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? MemberId { get; set; }

    public int? UserDeviceId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public bool IsDone { get; set; }

    public bool Pushed { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual User User { get; set; } = null!;
}
