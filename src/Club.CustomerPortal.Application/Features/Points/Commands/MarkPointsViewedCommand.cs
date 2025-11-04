namespace Club.CustomerPortal.Application.Features.Points.Commands;

public record MarkPointsViewedCommand : IRequest
{
    public required string PointTypeId { get; set; }
}

public class MarkPointsViewedCommandHandler : IRequestHandler<MarkPointsViewedCommand>
{
    private readonly IRequesterUser _requesterUser;
    private readonly ILogger<MarkPointsViewedCommandHandler> _logger;

    public MarkPointsViewedCommandHandler(
        IRequesterUser requesterUser,
        ILogger<MarkPointsViewedCommandHandler> logger)
    {
        _requesterUser = requesterUser;
        _logger = logger;
    }

    public Task Handle(MarkPointsViewedCommand request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        // TODO: علامت‌گذاری امتیازات به عنوان "مشاهده شده" در database
        // این ممکن است برای نوتیفیکیشن یا badge count استفاده شود
        
        _logger.LogInformation("Points marked as viewed for customer {CustomerId}, PointType {PointTypeId}",
            customerId, request.PointTypeId);
        
        return Task.CompletedTask;
    }
}

