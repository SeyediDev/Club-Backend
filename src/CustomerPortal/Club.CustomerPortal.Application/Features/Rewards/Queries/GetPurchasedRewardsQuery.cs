namespace Club.CustomerPortal.Application.Features.Rewards.Queries;

public record GetPurchasedRewardsQuery : IRequest<GetPurchasedRewardsQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Status { get; set; }
}

public record GetPurchasedRewardsQueryResponse
{
    public PaginatedList<PurchasedRewardDto> PurchasedRewards { get; set; } = null!;
}

public class GetPurchasedRewardsQueryHandler : IRequestHandler<GetPurchasedRewardsQuery, GetPurchasedRewardsQueryResponse>
{
    private readonly IRewardService _rewardService;
    private readonly IRequesterUser _requesterUser;

    public GetPurchasedRewardsQueryHandler(
        IRewardService rewardService,
        IRequesterUser requesterUser)
    {
        _rewardService = rewardService;
        _requesterUser = requesterUser;
    }

    public async Task<GetPurchasedRewardsQueryResponse> Handle(GetPurchasedRewardsQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        var result = await _rewardService.GetPurchasedRewardsAsync(
            customerId,
            request.PageNumber,
            request.PageSize,
            cancellationToken);
        
        var purchasedRewards = result.Items.Select(pr => new PurchasedRewardDto
        {
            Id = pr.Id,
            RewardId = 1, // TODO: get from actual data
            RewardTitle = pr.RewardTitle,
            RewardImageUrl = null,
            PurchasedAt = pr.PurchasedAt,
            Status = pr.Status,
            SerialNumber = pr.SerialNumber,
            QrCode = pr.QrCode,
            ExpirationDate = null,
            UsedDate = null,
            PointsSpent = pr.PointsSpent
        }).ToList();
        
        return new GetPurchasedRewardsQueryResponse
        {
            PurchasedRewards = new PaginatedList<PurchasedRewardDto>(
                purchasedRewards,
                result.TotalCount,
                request.PageNumber,
                request.PageSize)
        };
    }
}

