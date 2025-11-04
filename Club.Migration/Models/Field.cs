using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Field
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FieldTypeId { get; set; }

    public DateTime FieldStartDate { get; set; }

    public int FieldDegreeId { get; set; }

    public bool? Confirmed { get; set; }

    public int? ConfirmerUserId { get; set; }

    public DateTime? ConfrirmDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual FieldDegree FieldDegree { get; set; } = null!;

    public virtual FieldType FieldType { get; set; } = null!;
}
