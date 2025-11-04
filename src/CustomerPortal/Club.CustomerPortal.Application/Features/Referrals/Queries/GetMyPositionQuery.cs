namespace Club.CustomerPortal.Application.Features.Referrals.Queries;

public record GetMyPositionQuery : IRequest<GetMyPositionQueryResponse>
{
    public string? PointTypeId { get; set; }
}

public record GetMyPositionQueryResponse
{
    public int Rank { get; set; }
    public int TotalPoints { get; set; }
    public LeaderboardEntryDto Position { get; set; } = null!;
}

public class GetMyPositionQueryHandler : IRequestHandler<GetMyPositionQuery, GetMyPositionQueryResponse>
{
    private readonly IReferralService _referralService;
    private readonly IRequesterUser _requesterUser;

    public GetMyPositionQueryHandler(IReferralService referralService, IRequesterUser requesterUser)
    {
        _referralService = referralService;
        _requesterUser = requesterUser;
    }

    public async Task<GetMyPositionQueryResponse> Handle(GetMyPositionQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        var rank = await _referralService.GetCustomerPositionAsync(customerId, cancellationToken);
        
        return new GetMyPositionQueryResponse
        {
            Rank = rank,
            TotalPoints = 0,
            Position = new LeaderboardEntryDto
            {
                Rank = rank,
                CustomerId = customerId.ToString(),
                CustomerName = "شما",
                AvatarUrl = null,
                TotalPoints = 0,
                Level = null,
                Trend = null
            }
        };
    }
}

