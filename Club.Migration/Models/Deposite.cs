using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Deposite
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BankId { get; set; }

    public string Iban { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual Bank Bank { get; set; } = null!;
}
