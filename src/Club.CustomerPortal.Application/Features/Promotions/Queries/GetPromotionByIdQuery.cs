namespace Club.CustomerPortal.Application.Features.Promotions.Queries;

public record GetPromotionByIdQuery : IRequest<GetPromotionByIdQueryResponse>
{
    public string Id { get; set; } = null!;
}

public record GetPromotionByIdQueryResponse
{
    public PromotionDto Promotion { get; set; } = null!;
}

public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery, GetPromotionByIdQueryResponse>
{
    private readonly IPromotionService _promotionService;

    public GetPromotionByIdQueryHandler(IPromotionService promotionService)
    {
        _promotionService = promotionService;
    }

    public async Task<GetPromotionByIdQueryResponse> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
    {
        var promotion = await _promotionService.GetPromotionByIdAsync(int.Parse(request.Id), cancellationToken);
        
        if (promotion == null)
        {
            throw new InvalidOperationException("کمپین یافت نشد");
        }
        
        return new GetPromotionByIdQueryResponse
        {
            Promotion = new PromotionDto
            {
                Id = promotion.Id.ToString(),
                Name = promotion.Title,
                Description = promotion.Description ?? string.Empty,
                CategoryId = null,
                CategoryName = null,
                ImageUrl = promotion.ImageUrl,
                StartDate = promotion.StartDate,
                EndDate = promotion.EndDate,
                IsActive = promotion.IsActive,
                PromotionType = "Campaign",
                TermsAndConditions = null,
                ParticipationStatus = promotion.CanParticipate ? "Available" : "Unavailable"
            }
        };
    }
}

