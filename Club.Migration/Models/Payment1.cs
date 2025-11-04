using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Payment1
{
    public long Id { get; set; }

    public int UserId { get; set; }

    public long OrderId { get; set; }

    public int TerminalId { get; set; }

    public int Amount { get; set; }

    public string? RefNum { get; set; }

    public string? Message { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? VerifyDate { get; set; }

    public string? State { get; set; }

    public int? Status { get; set; }

    public string? Rrn { get; set; }

    public string? TraceNo { get; set; }

    public string? CardNumber { get; set; }

    public int? ResultCode { get; set; }

    public string? Iban { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual PaymentTerminal Terminal { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
