namespace Club.CustomerPortal.Application.Features.Auth.Commands;

public record RefreshTokenCommand : IRequest<RefreshTokenCommandResponse>
{
    public required string RefreshToken { get; set; }
}

public record RefreshTokenCommandResponse
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
}

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token الزامی است");
    }
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<RefreshTokenCommandHandler> _logger;

    public RefreshTokenCommandHandler(
        IAuthenticationService authenticationService,
        ILogger<RefreshTokenCommandHandler> logger)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var tokenResult = await _authenticationService.RefreshTokenAsync(request.RefreshToken, cancellationToken);

            _logger.LogInformation("Token refreshed successfully");

            return new RefreshTokenCommandResponse
            {
                Token = tokenResult.AccessToken,
                RefreshToken = tokenResult.RefreshToken,
                ExpiresIn = tokenResult.ExpiresIn
            };
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Token refresh failed");
            throw new UnauthorizedAccessException("توکن نامعتبر است");
        }
    }
}

