namespace Club.CustomerPortal.Application.Features.Auth.Commands;

public record ResetPasswordCommand : IRequest
{
    public required string Token { get; set; }
    public required string NewPassword { get; set; }
}

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Token).NotEmpty().WithMessage("Token الزامی است");
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6).WithMessage("رمز عبور باید حداقل 6 کاراکتر باشد");
    }
}

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<ResetPasswordCommandHandler> _logger;

    public ResetPasswordCommandHandler(
        ICustomerService customerService,
        ILogger<ResetPasswordCommandHandler> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await _customerService.ResetPasswordAsync(request.Token, request.NewPassword, cancellationToken);
        
        _logger.LogInformation("Password reset successfully");
    }
}

