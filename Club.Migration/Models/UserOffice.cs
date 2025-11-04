using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class UserOffice
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// نام
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// نام خانوادگی
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// کد ملی
    /// </summary>
    public long NationalCode { get; set; }

    /// <summary>
    /// سن
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// </summary>
    public byte GenderTypeId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual GenderType GenderType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
