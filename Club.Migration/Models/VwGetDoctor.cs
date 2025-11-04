using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwGetDoctor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? FieldTypeTitle { get; set; }

    public long MedicalCode { get; set; }

    public DateTime? ExpireDate { get; set; }

    public int FieldTypeId { get; set; }

    public bool? IsFavorite { get; set; }

    public int? DocumentId { get; set; }

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public int? Patients { get; set; }
}
