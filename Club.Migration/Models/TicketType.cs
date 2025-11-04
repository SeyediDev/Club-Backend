using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class TicketType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AppId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Type App { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
