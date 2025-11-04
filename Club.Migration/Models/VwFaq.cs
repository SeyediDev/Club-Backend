using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwFaq
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int SortIndex { get; set; }

    public string? AppName { get; set; }

    public string? Language { get; set; }
}
