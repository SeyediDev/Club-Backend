using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class FixedFee
{
    public int Id { get; set; }

    public int? FieldTypeId { get; set; }

    public double Value { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }
}
