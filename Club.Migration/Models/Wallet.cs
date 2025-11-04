using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Wallet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? UserAppId { get; set; }

    public int? UserDoctorId { get; set; }

    public long Balance { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual UserApp? UserApp { get; set; }

    public virtual UserDoctor? UserDoctor { get; set; }
}
