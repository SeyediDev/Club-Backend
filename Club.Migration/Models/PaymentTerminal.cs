using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class PaymentTerminal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual ICollection<Payment1> Payment1s { get; set; } = new List<Payment1>();
}
