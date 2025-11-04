namespace Club.CustomerPortal.Application.Features.Points.Commands;

public record TransferPointsCommand : IRequest
{
    public required string PointTypeId { get; set; }
    public required string ToCustomerId { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
}

public class TransferPointsCommandValidator : AbstractValidator<TransferPointsCommand>
{
    public TransferPointsCommandValidator()
    {
        RuleFor(x => x.PointTypeId).NotEmpty().WithMessage("نوع امتیاز الزامی است");
        RuleFor(x => x.ToCustomerId).NotEmpty().WithMessage("مشتری مقصد الزامی است");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("مقدار باید بیشتر از صفر باشد");
    }
}

public class TransferPointsCommandHandler : IRequestHandler<TransferPointsCommand>
{
    private readonly IPointService _pointService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<TransferPointsCommandHandler> _logger;

    public TransferPointsCommandHandler(
        IPointService pointService,
        IRequesterUser requesterUser,
        ILogger<TransferPointsCommandHandler> logger)
    {
        _pointService = pointService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task Handle(TransferPointsCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        var result = await _pointService.TransferPointsAsync(
            customerId,
            request.ToCustomerId, // این در واقع شماره موبایل است
            request.Amount,
            cancellationToken);
        
        if (!result.Success)
        {
            throw new InvalidOperationException(result.Message);
        }
        
        _logger.LogInformation("Points transferred successfully from customer {CustomerId} to {ToCustomer}: {Amount}",
            customerId, request.ToCustomerId, request.Amount);
    }
}

