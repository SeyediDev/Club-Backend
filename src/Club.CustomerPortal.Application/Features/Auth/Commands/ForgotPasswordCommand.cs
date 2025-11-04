namespace Club.CustomerPortal.Application.Features.Auth.Commands;

public record ForgotPasswordCommand : IRequest
{
    public required string Email { get; set; }
}

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("ایمیل نامعتبر است");
    }
}

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<ForgotPasswordCommandHandler> _logger;

    public ForgotPasswordCommandHandler(
        ICustomerService customerService,
        ILogger<ForgotPasswordCommandHandler> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }

    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _customerService.GetCustomerByEmailAsync(request.Email, cancellationToken);
            if (customer != null && !string.IsNullOrEmpty(customer.MobileNo))
            {
                var token = await _customerService.GeneratePasswordResetTokenAsync(customer.MobileNo, cancellationToken);
                
                // TODO: ارسال SMS با token به شماره موبایل یا ارسال ایمیل
                // await _smsService.SendPasswordResetSms(customer.MobileNo, token);
                // await _emailService.SendPasswordResetEmail(request.Email, token);
                
                _logger.LogInformation("Password reset token generated for email {Email}", request.Email);
            }
        }
        catch (Exception ex)
        {
            // برای امنیت، همیشه موفقیت نمایش می‌دهیم حتی اگر ایمیل وجود نداشته باشد
            _logger.LogWarning(ex, "Password reset requested for email {Email}", request.Email);
        }
    }
}

