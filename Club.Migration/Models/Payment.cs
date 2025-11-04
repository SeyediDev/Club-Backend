using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Amount { get; set; }

    public string Desciption { get; set; } = null!;

    public int Status { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? LastModifiedBy { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime? CreatedBy { get; set; }
}
