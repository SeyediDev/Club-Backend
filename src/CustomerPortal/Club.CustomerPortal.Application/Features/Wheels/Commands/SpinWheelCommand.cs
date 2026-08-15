using Club.CustomerPortal.Application.Interfaces;

namespace Club.CustomerPortal.Application.Features.Wheels.Commands;

public record SpinWheelCommand : IRequest<SpinWheelCommandResponse>;

public record SpinWheelCommandResponse
{
    public WheelSpinResultDto Result { get; init; } = null!;
}

public class SpinWheelCommandHandler(
    IWheelService wheelService,
    ICustomerRequesterUser requesterUser,
    ILogger<SpinWheelCommandHandler> logger) : IRequestHandler<SpinWheelCommand, SpinWheelCommandResponse>
{
    public async Task<SpinWheelCommandResponse> Handle(SpinWheelCommand request, CancellationToken cancellationToken)
    {
        var customerId = requesterUser.CustomerId;
        var result = await wheelService.SpinAsync(customerId, cancellationToken);

        logger.LogInformation("Customer {CustomerId} spun the loyalty wheel", customerId);

        return new SpinWheelCommandResponse
        {
            Result = result
        };
    }
}


































