using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class UserApp
{
    /// <summary>
    /// بیماران
    /// </summary>
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public long? NationalCode { get; set; }

    public DateOnly? BirthDate { get; set; }

    public byte? GenderTypeId { get; set; }

    public string? Address { get; set; }

    public string? ZipCode { get; set; }

    public int? ImageId { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual GenderType? GenderType { get; set; }

    public virtual Document? Image { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }

    public virtual ICollection<VisitRequest> VisitRequests { get; set; } = new List<VisitRequest>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
