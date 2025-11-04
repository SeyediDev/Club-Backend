namespace Club.CustomerPortal.Application.Features.Lotteries.Commands;

public record ParticipateInLotteryCommand : IRequest<ParticipateInLotteryCommandResponse>
{
    public string LotteryId { get; set; } = null!;
    public int Entries { get; set; } = 1;
}

public record ParticipateInLotteryCommandResponse
{
    public int EntryCount { get; set; }
    public int TotalEntries { get; set; }
}

public class ParticipateInLotteryCommandValidator : AbstractValidator<ParticipateInLotteryCommand>
{
    public ParticipateInLotteryCommandValidator()
    {
        RuleFor(x => x.LotteryId).NotEmpty().WithMessage("شناسه قرعه‌کشی الزامی است");
        RuleFor(x => x.Entries).GreaterThan(0).WithMessage("تعداد شانس باید بیشتر از صفر باشد");
    }
}

public class ParticipateInLotteryCommandHandler : IRequestHandler<ParticipateInLotteryCommand, ParticipateInLotteryCommandResponse>
{
    private readonly ILotteryService _lotteryService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<ParticipateInLotteryCommandHandler> _logger;

    public ParticipateInLotteryCommandHandler(
        ILotteryService lotteryService,
        IRequesterUser requesterUser,
        ILogger<ParticipateInLotteryCommandHandler> logger)
    {
        _lotteryService = lotteryService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task<ParticipateInLotteryCommandResponse> Handle(ParticipateInLotteryCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        var result = await _lotteryService.ParticipateInLotteryAsync(customerId, int.Parse(request.LotteryId), cancellationToken);
        
        if (!result.Success)
        {
            throw new InvalidOperationException(result.Message);
        }
        
        _logger.LogInformation("Customer {CustomerId} participated in lottery {LotteryId}", customerId, request.LotteryId);
        
        return new ParticipateInLotteryCommandResponse
        {
            EntryCount = request.Entries,
            TotalEntries = request.Entries
        };
    }
}

