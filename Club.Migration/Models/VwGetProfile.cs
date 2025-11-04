using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class VwGetProfile
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime CreateDate { get; set; }

    public int UserCount { get; set; }

    public int? DocumentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public int CountryCode { get; set; }

    public long Mobile { get; set; }
}
