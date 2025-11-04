using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int AppId { get; set; }

    public int UserId { get; set; }

    public string Subject { get; set; } = null!;

    public int TicketTypeId { get; set; }

    public int TicketStatusId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Type App { get; set; } = null!;

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();

    public virtual TicketStatus TicketStatus { get; set; } = null!;

    public virtual TicketType TicketType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
