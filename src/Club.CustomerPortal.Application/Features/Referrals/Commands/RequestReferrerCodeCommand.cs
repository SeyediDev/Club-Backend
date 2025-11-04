namespace Club.CustomerPortal.Application.Features.Referrals.Commands;

public record RequestReferrerCodeCommand : IRequest;

public class RequestReferrerCodeCommandHandler : IRequestHandler<RequestReferrerCodeCommand>
{
    private readonly IReferralService _referralService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<RequestReferrerCodeCommandHandler> _logger;

    public RequestReferrerCodeCommandHandler(IReferralService referralService, IRequesterUser requesterUser, ILogger<RequestReferrerCodeCommandHandler> logger)
    {
        _referralService = referralService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task Handle(RequestReferrerCodeCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        var code = await _referralService.RequestReferrerCodeAsync(customerId, cancellationToken);
        _logger.LogInformation("Referrer code requested for customer {CustomerId}: {Code}", customerId, code);
    }
}

