namespace Club.Domain.Entities.Common;

public abstract class ClubBaseCoreConfigAuditableEntity<TKey> : BaseCoreConfigAuditableEntity<TKey>
    where TKey : struct
{
    [NotMapped]
    [DisplayName("ایجاد کننده")]
    public User? CreatedBy { get; set; }
    
    [NotMapped]
    [DisplayName("تغییر دهنده")]
    public User? LastModifiedBy { get; set; }
}

public abstract class ClubBaseCoreAuditableEntity<TKey> : BaseCoreAuditableEntity<TKey>
    where TKey : struct
{
    [NotMapped]
    [DisplayName("ایجاد کننده")]
    public User? CreatedBy { get; set; }
    
    [NotMapped]
    [DisplayName("تغییر دهنده")]
    public User? LastModifiedBy { get; set; }
}

public abstract class ClubBaseCoreLogAuditableEntity<TKey> : BaseCoreLogAuditableEntity<TKey>
    where TKey : struct
{
    [NotMapped]
    [DisplayName("ایجاد کننده")]
    public User? CreatedBy { get; set; }
    
    [NotMapped]
    [DisplayName("تغییر دهنده")]
    public User? LastModifiedBy { get; set; }
}
