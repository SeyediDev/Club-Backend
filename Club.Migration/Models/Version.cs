using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Version
{
    public int Id { get; set; }

    public string Version1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime? LastModifiedBy { get; set; }
}
