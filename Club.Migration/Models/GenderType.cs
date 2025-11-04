using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class GenderType
{
    public byte Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<UserApp> UserApps { get; set; } = new List<UserApp>();

    public virtual ICollection<UserDoctor> UserDoctors { get; set; } = new List<UserDoctor>();

    public virtual ICollection<UserOffice> UserOffices { get; set; } = new List<UserOffice>();
}
