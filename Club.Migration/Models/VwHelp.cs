using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwHelp
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public string? AppName { get; set; }

    public string? Language { get; set; }
}
