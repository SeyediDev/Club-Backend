namespace Club.Domain.Entities.Promotions;

public interface ISubOfPromotion
{
    int PromotionId { get; set; }
    Promotion Promotion { get; set; }
}
