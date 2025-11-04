using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class UserType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime? LastModifiedBy { get; set; }
}
