using Club.CustomerPortal.Application.Interfaces;

namespace Club.CustomerPortal.Application.Services;

/// <summary>
/// Mock implementation برای تست
/// </summary>
public class MockRewardService : IRewardService
{
    private readonly ILogger<MockRewardService> _logger;
    private static readonly List<PurchasedRewardDto> _purchasedRewards = new();

    public MockRewardService(ILogger<MockRewardService> logger)
    {
        _logger = logger;
    }

    public Task<PaginatedList<Interfaces.RewardDto>> GetRewardsAsync(int? categoryId = null, string? searchTerm = null, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var rewards = new List<Interfaces.RewardDto>
        {
            new() { Id = 1, Title = "کارت هدیه 50 هزار تومانی", Description = "کارت هدیه دیجیتال", Value = 5000, Quantity = 100, Picture = null, CategoryName = "کارت هدیه", MerchantName = "فروشگاه آنلاین", IsAvailable = true },
            new() { Id = 2, Title = "تخفیف 20 درصدی", Description = "کد تخفیف خرید", Value = 2000, Quantity = 50, Picture = null, CategoryName = "تخفیف", MerchantName = "فروشگاه", IsAvailable = true }
        };

        return Task.FromResult(new PaginatedList<Interfaces.RewardDto>(rewards, 2, pageNumber, pageSize));
    }

    public Task<Interfaces.RewardDto?> GetRewardByIdAsync(int rewardId, CancellationToken cancellationToken = default)
    {
        var reward = new Interfaces.RewardDto
        {
            Id = rewardId,
            Title = "پاداش نمونه",
            Description = "توضیحات پاداش",
            Value = 1000,
            Quantity = 10,
            Picture = null,
            CategoryName = "عمومی",
            MerchantName = "فروشگاه",
            IsAvailable = true
        };

        return Task.FromResult<Interfaces.RewardDto?>(reward);
    }

    public Task<PurchaseRewardResultDto> PurchaseRewardAsync(int customerId, int rewardId, int quantity = 1, CancellationToken cancellationToken = default)
    {
        var serial = $"SN-{Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper()}";
        var qrCode = $"QR-{customerId}-{rewardId}-{DateTime.Now.Ticks}";

        var purchasedReward = new PurchasedRewardDto
        {
            Id = _purchasedRewards.Count + 1,
            RewardId = rewardId,
            RewardTitle = "پاداش خریداری شده",
            SerialNumber = serial,
            QrCode = qrCode,
            PurchasedAt = DateTime.UtcNow,
            PointsSpent = 1000,
            Status = "Active"
        };

        _purchasedRewards.Add(purchasedReward);

        _logger.LogInformation("Mock: Purchased reward {RewardId} for customer {CustomerId}", rewardId, customerId);

        return Task.FromResult(new PurchaseRewardResultDto
        {
            Success = true,
            SerialNumber = serial,
            QrCode = qrCode,
            Message = "پاداش با موفقیت خریداری شد"
        });
    }

    public Task<PaginatedList<PurchasedRewardDto>> GetPurchasedRewardsAsync(int customerId, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new PaginatedList<PurchasedRewardDto>(_purchasedRewards, _purchasedRewards.Count, pageNumber, pageSize));
    }

    public Task<IEnumerable<Interfaces.RewardCategoryDto>> GetRewardCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = new List<Interfaces.RewardCategoryDto>
        {
            new() { Id = 1, Name = "کارت هدیه", RewardCount = 10 },
            new() { Id = 2, Name = "تخفیف", RewardCount = 5 },
            new() { Id = 3, Name = "محصولات", RewardCount = 15 }
        };

        return Task.FromResult<IEnumerable<Interfaces.RewardCategoryDto>>(categories);
    }
}

