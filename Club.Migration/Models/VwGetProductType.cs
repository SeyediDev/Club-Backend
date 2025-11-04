using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwGetProductType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsService { get; set; }

    public string Language { get; set; } = null!;
}
