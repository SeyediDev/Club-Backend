using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Chat
{
    public long Id { get; set; }

    public int UserAppId { get; set; }

    public int UserDoctorId { get; set; }

    public int? VisitRequestId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<ChatDetail> ChatDetails { get; set; } = new List<ChatDetail>();

    public virtual UserApp UserApp { get; set; } = null!;

    public virtual UserDoctor UserDoctor { get; set; } = null!;

    public virtual VisitRequest? VisitRequest { get; set; }
}
