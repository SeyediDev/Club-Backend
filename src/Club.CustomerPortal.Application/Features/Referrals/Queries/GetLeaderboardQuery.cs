namespace Club.CustomerPortal.Application.Features.Referrals.Queries;

public record GetLeaderboardQuery : IRequest<GetLeaderboardQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
    public string? PointTypeId { get; set; }
    public string? Period { get; set; }
}

public record GetLeaderboardQueryResponse
{
    public PaginatedList<LeaderboardEntryDto> Entries { get; set; } = null!;
}

public record LeaderboardEntryDto
{
    public int Rank { get; set; }
    public string CustomerId { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public int TotalPoints { get; set; }
    public string? Level { get; set; }
    public string? Trend { get; set; }
}

public class GetLeaderboardQueryHandler : IRequestHandler<GetLeaderboardQuery, GetLeaderboardQueryResponse>
{
    private readonly IReferralService _referralService;
    private readonly IRequesterUser _requesterUser;

    public GetLeaderboardQueryHandler(IReferralService referralService, IRequesterUser requesterUser)
    {
        _referralService = referralService;
        _requesterUser = requesterUser;
    }

    public async Task<GetLeaderboardQueryResponse> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _requesterUser.GetUserId();
        var result = await _referralService.GetLeaderboardAsync(request.PageNumber, request.PageSize, cancellationToken);
        
        var entries = result.Items.Select(e => new LeaderboardEntryDto
        {
            Rank = e.Rank,
            CustomerId = currentUserId.ToString(),
            CustomerName = e.CustomerName,
            AvatarUrl = e.AvatarUrl,
            TotalPoints = (int)e.TotalPoints,
            Level = null,
            Trend = null
        }).ToList();
        
        return new GetLeaderboardQueryResponse
        {
            Entries = new PaginatedList<LeaderboardEntryDto>(entries, result.TotalCount, request.PageNumber, request.PageSize)
        };
    }
}

