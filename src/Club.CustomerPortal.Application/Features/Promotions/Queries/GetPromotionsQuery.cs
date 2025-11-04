namespace Club.CustomerPortal.Application.Features.Promotions.Queries;

public record GetPromotionsQuery : IRequest<GetPromotionsQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? CategoryId { get; set; }
    public bool? IsActive { get; set; }
    public string? PromotionType { get; set; }
}

public record GetPromotionsQueryResponse
{
    public PaginatedList<PromotionDto> Promotions { get; set; } = null!;
}

public record PromotionDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public string PromotionType { get; set; } = null!;
    public string? TermsAndConditions { get; set; }
    public string? ParticipationStatus { get; set; }
}

public class GetPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery, GetPromotionsQueryResponse>
{
    private readonly IPromotionService _promotionService;

    public GetPromotionsQueryHandler(IPromotionService promotionService)
    {
        _promotionService = promotionService;
    }

    public async Task<GetPromotionsQueryResponse> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
    {
        var result = await _promotionService.GetActivePromotionsAsync(request.PageNumber, request.PageSize, cancellationToken);
        
        var promotions = result.Items.Select(p => new PromotionDto
        {
            Id = p.Id.ToString(),
            Name = p.Title,
            Description = p.Description ?? string.Empty,
            CategoryId = null,
            CategoryName = null,
            ImageUrl = p.ImageUrl,
            StartDate = p.StartDate,
            EndDate = p.EndDate,
            IsActive = p.IsActive,
            PromotionType = "Campaign",
            TermsAndConditions = null,
            ParticipationStatus = p.CanParticipate ? "Available" : "Unavailable"
        }).ToList();
        
        return new GetPromotionsQueryResponse
        {
            Promotions = new PaginatedList<PromotionDto>(promotions, result.TotalCount, request.PageNumber, request.PageSize)
        };
    }
}
