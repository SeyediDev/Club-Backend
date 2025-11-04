namespace Club.CustomerPortal.Application.Features.Auth.Commands;

public record ChangePasswordCommand : IRequest
{
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
}

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("رمز عبور فعلی الزامی است");
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6).WithMessage("رمز عبور جدید باید حداقل 6 کاراکتر باشد");
    }
}


public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
{
    private readonly ICustomerService _customerService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<ChangePasswordCommandHandler> _logger;

    public ChangePasswordCommandHandler(
        ICustomerService customerService,
        IRequesterUser requesterUser,
        ILogger<ChangePasswordCommandHandler> logger)
    {
        _customerService = customerService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();

        await _customerService.ChangePasswordAsync(
            customerId,
            request.CurrentPassword,
            request.NewPassword,
            cancellationToken);

        _logger.LogInformation("Password changed successfully for customer {CustomerId}", customerId);
    }
}
