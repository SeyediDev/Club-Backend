using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwGetPlan
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte ValidDays { get; set; }

    public byte CardiologistInterpretation { get; set; }

    public byte? Aiinterpretation { get; set; }

    public byte MemberCount { get; set; }

    public int BasePrice { get; set; }

    public int Price { get; set; }

    public string? Details { get; set; }
}
