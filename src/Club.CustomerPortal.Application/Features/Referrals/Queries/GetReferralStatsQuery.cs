namespace Club.CustomerPortal.Application.Features.Referrals.Queries;

public record GetReferralStatsQuery : IRequest<GetReferralStatsQueryResponse>;

public record GetReferralStatsQueryResponse
{
    public int TotalReferrals { get; set; }
    public int ActiveReferrals { get; set; }
    public int TotalPointsEarned { get; set; }
    public string ReferralCode { get; set; } = null!;
    public string ReferralLink { get; set; } = null!;
}

public class GetReferralStatsQueryHandler : IRequestHandler<GetReferralStatsQuery, GetReferralStatsQueryResponse>
{
    private readonly IReferralService _referralService;
    private readonly IRequesterUser _requesterUser;

    public GetReferralStatsQueryHandler(IReferralService referralService, IRequesterUser requesterUser)
    {
        _referralService = referralService;
        _requesterUser = requesterUser;
    }

    public async Task<GetReferralStatsQueryResponse> Handle(GetReferralStatsQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        var stats = await _referralService.GetReferralStatsAsync(customerId, cancellationToken);
        
        return new GetReferralStatsQueryResponse
        {
            TotalReferrals = stats.TotalReferrals,
            ActiveReferrals = stats.ActiveReferrals,
            TotalPointsEarned = (int)stats.TotalPointsEarned,
            ReferralCode = stats.MyReferrerCode ?? string.Empty,
            ReferralLink = $"https://portal.club.com/register?ref={stats.MyReferrerCode}"
        };
    }
}

