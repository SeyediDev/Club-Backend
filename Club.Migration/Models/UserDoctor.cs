using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class UserDoctor
{
    /// <summary>
    /// پزشکان
    /// </summary>
    public int Id { get; set; }

    public int? UserId { get; set; }

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

    /// <summary>
    /// کد نظام پزشکی
    /// </summary>
    public long MedicalCode { get; set; }

    public int? ImageId { get; set; }

    public bool? Confirmed { get; set; }

    public int? ConfirmerUserId { get; set; }

    public DateTime? ConfirmDate { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual GenderType GenderType { get; set; } = null!;

    public virtual Document? Image { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }

    public virtual ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
