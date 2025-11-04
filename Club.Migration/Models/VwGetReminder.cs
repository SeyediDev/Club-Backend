using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwGetReminder
{
    public int Id { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserLastName { get; set; }

    public string? MemberFirstName { get; set; }

    public string? MemberLastName { get; set; }

    public DateTime DueDate { get; set; }

    public bool IsDone { get; set; }

    public string Title { get; set; } = null!;

    public int? DocumentId { get; set; }

    public int UserId { get; set; }

    public int? MemberId { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime? MemberExpireDate { get; set; }
}
