namespace Club.Domain.Entities.Rewards;

/// <summary>
/// طبقه‌بندی محصولات را اینجا لیست می کنیم
/// </summary>
[DisplayName("طبقه‌بندی پاداش")]
[OldDbMap("ProductCategories")]
public class RewardCategory : ClubBaseCoreAuditableEntity<int>
{
    [DisplayName("عنوان")] [InDisplayString]
    [MaxLength(41)]
    public string Title { get; set; } = null!;

    public int? CategoryId { get; set; }
    [DisplayName("طبقه‌بندی مافوق")]
    public RewardCategory? Category { get; set; } = null!;
}
