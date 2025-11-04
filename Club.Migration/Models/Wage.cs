using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Wage
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int FieldId { get; set; }

    public int Value { get; set; }

    public int CommissionId { get; set; }

    public DateTime CreateDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int LastModifiedBy { get; set; }
}
