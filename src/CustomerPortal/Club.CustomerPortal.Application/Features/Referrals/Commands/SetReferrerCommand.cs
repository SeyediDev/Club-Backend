namespace Club.CustomerPortal.Application.Features.Referrals.Commands;

public record SetReferrerCommand : IRequest
{
    public required string ReferrerCode { get; set; }
}

public class SetReferrerCommandValidator : AbstractValidator<SetReferrerCommand>
{
    public SetReferrerCommandValidator()
    {
        RuleFor(x => x.ReferrerCode).NotEmpty().WithMessage("کد معرف الزامی است");
    }
}

public class SetReferrerCommandHandler : IRequestHandler<SetReferrerCommand>
{
    private readonly IReferralService _referralService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<SetReferrerCommandHandler> _logger;

    public SetReferrerCommandHandler(IReferralService referralService, IRequesterUser requesterUser, ILogger<SetReferrerCommandHandler> logger)
    {
        _referralService = referralService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task Handle(SetReferrerCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        await _referralService.SetReferrerAsync(customerId, request.ReferrerCode, cancellationToken);
        _logger.LogInformation("Referrer set for customer {CustomerId}: {Code}", customerId, request.ReferrerCode);
    }
}

