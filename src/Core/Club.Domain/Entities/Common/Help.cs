using Neo.Domain.Entities.Common;

namespace Club.Domain.Entities.Common;

public class Help : ClubBaseCoreConfigAuditableEntity<int>
{
    [MaxLength(512)]
    public string Content { get; set; } = null!;
    public LanguageId LanguageId { get; set; }
    public Language Language { get; set; } = null!;
}
