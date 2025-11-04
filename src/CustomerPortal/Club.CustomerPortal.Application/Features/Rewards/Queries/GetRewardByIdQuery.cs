namespace Club.CustomerPortal.Application.Features.Rewards.Queries;

public record GetRewardByIdQuery : IRequest<GetRewardByIdQueryResponse>
{
    public string Id { get; set; } = null!;
}

public record GetRewardByIdQueryResponse
{
    public RewardDto Reward { get; set; } = null!;
}

public class GetRewardByIdQueryHandler : IRequestHandler<GetRewardByIdQuery, GetRewardByIdQueryResponse>
{
    private readonly IRewardService _rewardService;

    public GetRewardByIdQueryHandler(IRewardService rewardService)
    {
        _rewardService = rewardService;
    }

    public async Task<GetRewardByIdQueryResponse> Handle(GetRewardByIdQuery request, CancellationToken cancellationToken)
    {
        var reward = await _rewardService.GetRewardByIdAsync(int.Parse(request.Id), cancellationToken);
        
        if (reward == null)
        {
            throw new InvalidOperationException("پاداش یافت نشد");
        }
        
        return new GetRewardByIdQueryResponse
        {
            Reward = new RewardDto
            {
                Id = reward.Id.ToString(),
                Name = reward.Title,
                Description = reward.Description ?? string.Empty,
                CategoryId = "1",
                CategoryName = reward.CategoryName,
                ImageUrl = reward.Picture,
                Costs =
                [
                    new RewardCostDto
                    {
                        PointTypeId = "1",
                        PointTypeName = "امتیاز طلایی",
                        PointTypeColor = "#FFD700",
                        Amount = (int)reward.Value
                    }
                ],
                Stock = reward.Quantity,
                IsAvailable = reward.IsAvailable,
                ValidFrom = null,
                ValidTo = null,
                TermsAndConditions = null,
                Merchant = new MerchantDto
                {
                    Id = "1",
                    Name = reward.MerchantName,
                    LogoUrl = null
                }
            }
        };
    }
}

