namespace Club.CustomerPortal.Application.Features.Rewards.Queries;

public record GetRewardsQuery : IRequest<GetRewardsQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? CategoryId { get; set; }
    public bool? IsAvailable { get; set; }
    public string? Search { get; set; }
}

public record GetRewardsQueryResponse
{
    public PaginatedList<RewardDto> Rewards { get; set; } = null!;
}

public record RewardDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public List<RewardCostDto> Costs { get; set; } = [];
    public int? Stock { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string? TermsAndConditions { get; set; }
    public MerchantDto? Merchant { get; set; }
}

public record RewardCostDto
{
    public string PointTypeId { get; set; } = null!;
    public string PointTypeName { get; set; } = null!;
    public string PointTypeColor { get; set; } = null!;
    public int Amount { get; set; }
}

public record MerchantDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? LogoUrl { get; set; }
}

public class GetRewardsQueryHandler : IRequestHandler<GetRewardsQuery, GetRewardsQueryResponse>
{
    private readonly IRewardService _rewardService;

    public GetRewardsQueryHandler(IRewardService rewardService)
    {
        _rewardService = rewardService;
    }

    public async Task<GetRewardsQueryResponse> Handle(GetRewardsQuery request, CancellationToken cancellationToken)
    {
        var categoryId = string.IsNullOrEmpty(request.CategoryId) ? null : (int?)int.Parse(request.CategoryId);
        
        var result = await _rewardService.GetRewardsAsync(
            categoryId,
            request.Search,
            request.PageNumber,
            request.PageSize,
            cancellationToken);
        
        var rewards = result.Items.Select(r => new RewardDto
        {
            Id = r.Id.ToString(),
            Name = r.Title,
            Description = r.Description ?? string.Empty,
            CategoryId = "1", // TODO: از database
            CategoryName = r.CategoryName,
            ImageUrl = r.Picture,
            Costs =
            [
                new RewardCostDto
                {
                    PointTypeId = "1",
                    PointTypeName = "امتیاز طلایی",
                    PointTypeColor = "#FFD700",
                    Amount = (int)r.Value
                }
            ],
            Stock = r.Quantity,
            IsAvailable = r.IsAvailable,
            ValidFrom = null,
            ValidTo = null,
            TermsAndConditions = null,
            Merchant = new MerchantDto
            {
                Id = "1",
                Name = r.MerchantName,
                LogoUrl = null
            }
        }).ToList();
        
        return new GetRewardsQueryResponse
        {
            Rewards = new PaginatedList<RewardDto>(
                rewards,
                result.TotalCount,
                request.PageNumber,
                request.PageSize)
        };
    }
}

