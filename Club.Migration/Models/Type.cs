using System;
using System.Collections.Generic;

namespace Club.Migration.Models;

public partial class Type
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Header { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ExpireDate { get; set; }

    public DateTime LastModified { get; set; }

    public int? LastModifiedBy { get; set; }

    public virtual ICollection<CultureTerm> CultureTerms { get; set; } = new List<CultureTerm>();

    public virtual ICollection<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

    public virtual ICollection<Faq> Faqs { get; set; } = new List<Faq>();

    public virtual ICollection<Help> Helps { get; set; } = new List<Help>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<PrivacyAndPolicy> PrivacyAndPolicies { get; set; } = new List<PrivacyAndPolicy>();

    public virtual ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
