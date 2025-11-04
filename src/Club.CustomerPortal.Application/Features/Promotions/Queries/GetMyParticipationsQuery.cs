namespace Club.CustomerPortal.Application.Features.Promotions.Queries;

public record GetMyParticipationsQuery : IRequest<GetMyParticipationsQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Status { get; set; }
}

public record GetMyParticipationsQueryResponse
{
    public PaginatedList<PromotionParticipationDto> Participations { get; set; } = null!;
}

public record PromotionParticipationDto
{
    public PromotionDto Promotion { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime ParticipatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}

public class GetMyParticipationsQueryHandler : IRequestHandler<GetMyParticipationsQuery, GetMyParticipationsQueryResponse>
{
    private readonly IPromotionService _promotionService;
    private readonly IRequesterUser _requesterUser;

    public GetMyParticipationsQueryHandler(
        IPromotionService promotionService,
        IRequesterUser requesterUser)
    {
        _promotionService = promotionService;
        _requesterUser = requesterUser;
    }

    public async Task<GetMyParticipationsQueryResponse> Handle(GetMyParticipationsQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.Id ?? throw new UnauthorizedAccessException("User ID not found");
        var result = await _promotionService.GetMyParticipationsAsync(customerId, request.PageNumber, request.PageSize, cancellationToken);
        
        var participations = result.Items.Select(p => new PromotionParticipationDto
        {
            Promotion = new PromotionDto
            {
                Id = p.PromotionId.ToString(),
                Name = p.PromotionTitle,
                Description = string.Empty,
                CategoryId = null,
                CategoryName = null,
                ImageUrl = null,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                IsActive = true,
                PromotionType = "Campaign",
                TermsAndConditions = null,
                ParticipationStatus = p.Status
            },
            Status = p.Status,
            ParticipatedDate = p.ParticipatedAt,
            CompletedDate = null
        }).ToList();
        
        return new GetMyParticipationsQueryResponse
        {
            Participations = new PaginatedList<PromotionParticipationDto>(participations, result.TotalCount, request.PageNumber, request.PageSize)
        };
    }
}

