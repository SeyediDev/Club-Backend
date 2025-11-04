using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwGetMemberActivity
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public int UserId { get; set; }
}
