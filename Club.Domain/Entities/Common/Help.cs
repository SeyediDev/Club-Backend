namespace Club.Domain.Entities.Common;

public class Help : ClubBaseCoreCommonAuditableEntity<int>
{
    [MaxLength(512)]
    public string Content { get; set; } = null!;
    public int LanguageId { get; set; }
    public Language Language { get; set; } = null!;
}
