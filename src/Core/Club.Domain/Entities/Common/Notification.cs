namespace Club.Domain.Entities.Common;

public partial class Notification: ClubBaseCoreCommonAuditableEntity<int>
{
    public int UserId { get; set; }
    public virtual User? User { get; set; }

    [MaxLength(41)]
    public string Title { get; set; } = null!;
    [MaxLength(512)]
    public string? Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
}
