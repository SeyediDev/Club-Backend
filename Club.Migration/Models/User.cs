using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class User
{
    /// <summary>
    /// کاربران
    /// </summary>
    public int Id { get; set; }

    public int CountryCode { get; set; }

    public long Mobile { get; set; }

    public string? Email { get; set; }

    public bool Verified { get; set; }

    public byte[]? Otpseed { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ICollection<ChatDetail> ChatDetails { get; set; } = new List<ChatDetail>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Payment1> Payment1s { get; set; } = new List<Payment1>();

    public virtual ICollection<QuestionAnswer1> QuestionAnswer1s { get; set; } = new List<QuestionAnswer1>();

    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

    public virtual ICollection<Settlement> Settlements { get; set; } = new List<Settlement>();

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<UserAppDevice> UserAppDevices { get; set; } = new List<UserAppDevice>();

    public virtual ICollection<UserApp> UserApps { get; set; } = new List<UserApp>();

    public virtual ICollection<UserDoctor> UserDoctors { get; set; } = new List<UserDoctor>();

    public virtual ICollection<UserOffice> UserOffices { get; set; } = new List<UserOffice>();

    public virtual ICollection<UserPlan> UserPlans { get; set; } = new List<UserPlan>();

    public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
}
