namespace Club.Domain.Entities.Events;

/// <summary>
/// رویداد را اینجا لیست می کنیم
/// </summary>
[DisplayName("رویداد")]
public class EventType : ClubBaseCoreConfigAuditableEntity<int>
{
    [MaxLength(40)]
    //[Unique]
    [DisplayName("کلید")]
    public string Key { get; set; } = null!;
    //[Unique]
    [DisplayName("عنوان")] [InDisplayString]
    [MaxLength(41)]
    public string Title { get; set; } = null!;
}
