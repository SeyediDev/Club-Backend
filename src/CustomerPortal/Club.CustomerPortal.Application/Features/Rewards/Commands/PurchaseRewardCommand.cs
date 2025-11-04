namespace Club.CustomerPortal.Application.Features.Rewards.Commands;

public record PurchaseRewardCommand : IRequest<PurchaseRewardCommandResponse>
{
    public required string RewardId { get; set; }
    public int Quantity { get; set; } = 1;
}

public record PurchaseRewardCommandResponse
{
    public PurchasedRewardDto PurchasedReward { get; set; } = null!;
}

public class PurchaseRewardCommandValidator : AbstractValidator<PurchaseRewardCommand>
{
    public PurchaseRewardCommandValidator()
    {
        RuleFor(x => x.RewardId).NotEmpty().WithMessage("شناسه پاداش الزامی است");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("تعداد باید بیشتر از صفر باشد");
    }
}

public class PurchaseRewardCommandHandler : IRequestHandler<PurchaseRewardCommand, PurchaseRewardCommandResponse>
{
    private readonly IRewardService _rewardService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<PurchaseRewardCommandHandler> _logger;

    public PurchaseRewardCommandHandler(
        IRewardService rewardService,
        IRequesterUser requesterUser,
        ILogger<PurchaseRewardCommandHandler> logger)
    {
        _rewardService = rewardService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task<PurchaseRewardCommandResponse> Handle(PurchaseRewardCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.Id ?? throw new UnauthorizedAccessException("User ID not found");
        
        var result = await _rewardService.PurchaseRewardAsync(
            customerId,
            int.Parse(request.RewardId),
            request.Quantity,
            cancellationToken);
        
        if (!result.Success)
        {
            throw new InvalidOperationException(result.Message);
        }
        
        _logger.LogInformation("Reward purchased successfully by customer {CustomerId}: Reward {RewardId} x {Quantity}",
            customerId, request.RewardId, request.Quantity);
        
        return new PurchaseRewardCommandResponse
        {
            PurchasedReward = new PurchasedRewardDto
            {
                Id = 0, // Will be set by database
                RewardId = int.Parse(request.RewardId),
                RewardTitle = "پاداش",
                RewardImageUrl = null,
                PurchasedAt = DateTime.UtcNow,
                Status = "Active",
                SerialNumber = result.SerialNumber,
                QrCode = result.QrCode,
                ExpirationDate = null,
                UsedDate = null,
                PointsSpent = 0 // TODO: get from result
            }
        };
    }
}

