namespace Club.CustomerPortal.Application.Features.Promotions.Commands;

public record ParticipateInPromotionCommand : IRequest<ParticipateInPromotionCommandResponse>
{
    public string PromotionId { get; set; } = null!;
}

public record ParticipateInPromotionCommandResponse
{
    public string Status { get; set; } = null!;
}

public class ParticipateInPromotionCommandValidator : AbstractValidator<ParticipateInPromotionCommand>
{
    public ParticipateInPromotionCommandValidator()
    {
        RuleFor(x => x.PromotionId).NotEmpty().WithMessage("شناسه کمپین الزامی است");
    }
}

public class ParticipateInPromotionCommandHandler : IRequestHandler<ParticipateInPromotionCommand, ParticipateInPromotionCommandResponse>
{
    private readonly IPromotionService _promotionService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<ParticipateInPromotionCommandHandler> _logger;

    public ParticipateInPromotionCommandHandler(
        IPromotionService promotionService,
        IRequesterUser requesterUser,
        ILogger<ParticipateInPromotionCommandHandler> logger)
    {
        _promotionService = promotionService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task<ParticipateInPromotionCommandResponse> Handle(ParticipateInPromotionCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.Id ?? throw new UnauthorizedAccessException("User ID not found");
        var result = await _promotionService.ParticipateAsync(customerId, int.Parse(request.PromotionId), cancellationToken);
        
        if (!result.Success)
        {
            throw new InvalidOperationException(result.Message);
        }
        
        _logger.LogInformation("Customer {CustomerId} participated in promotion {PromotionId}", customerId, request.PromotionId);
        
        return new ParticipateInPromotionCommandResponse
        {
            Status = "Success"
        };
    }
}

