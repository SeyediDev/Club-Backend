namespace Club.CustomerPortal.Application.Features.Auth.Commands;

public record UpdateProfileCommand : IRequest<UpdateProfileCommandResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NationalCode { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? AvatarUrl { get; set; }
}

public record UpdateProfileCommandResponse
{
    public required CustomerDto Customer { get; set; }
}

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        When(x => !string.IsNullOrEmpty(x.Email), () =>
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("ایمیل نامعتبر است");
        });
        When(x => !string.IsNullOrEmpty(x.PhoneNumber), () =>
        {
            RuleFor(x => x.PhoneNumber).Matches(@"^09\d{9}$").WithMessage("شماره موبایل نامعتبر است");
        });
    }
}

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, UpdateProfileCommandResponse>
{
    private readonly ICustomerService _customerService;
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<UpdateProfileCommandHandler> _logger;

    public UpdateProfileCommandHandler(
        ICustomerService customerService,
        IRequesterUser requesterUser,
        ILogger<UpdateProfileCommandHandler> logger)
    {
        _customerService = customerService;
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public async Task<UpdateProfileCommandResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        var updatedCustomer = await _customerService.UpdateCustomerAsync(customerId, request, cancellationToken);
        
        _logger.LogInformation("Profile updated successfully for customer {CustomerId}", customerId);
        
        return new UpdateProfileCommandResponse
        {
            Customer = updatedCustomer.Adapt<CustomerDto>()
        };
    }
}

