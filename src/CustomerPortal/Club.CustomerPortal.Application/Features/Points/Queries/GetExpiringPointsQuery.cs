namespace Club.CustomerPortal.Application.Features.Points.Queries;

public record GetExpiringPointsQuery : IRequest<GetExpiringPointsQueryResponse>;

public record GetExpiringPointsQueryResponse
{
    public List<ExpiringPointDto> ExpiringPoints { get; set; } = [];
}

public record ExpiringPointDto
{
    public PointTypeDto PointType { get; set; } = null!;
    public int Amount { get; set; }
    public DateTime ExpirationDate { get; set; }
}

public class GetExpiringPointsQueryHandler : IRequestHandler<GetExpiringPointsQuery, GetExpiringPointsQueryResponse>
{
    private readonly IPointService _pointService;
    private readonly IRequesterUser _requesterUser;

    public GetExpiringPointsQueryHandler(
        IPointService pointService,
        IRequesterUser requesterUser)
    {
        _pointService = pointService;
        _requesterUser = requesterUser;
    }

    public async Task<GetExpiringPointsQueryResponse> Handle(GetExpiringPointsQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        var expiringPoints = await _pointService.GetExpiringPointsAsync(customerId, 30, cancellationToken);
        
        var result = expiringPoints.Select(ep => new ExpiringPointDto
        {
            PointType = new PointTypeDto
            {
                Id = "1",
                Name = "امتیاز طلایی",
                Description = "امتیاز اصلی",
                Color = "#FFD700",
                Icon = "star",
                IsConvertible = true,
                IsTransferable = true,
                ExpirationDays = 365
            },
            Amount = (int)ep.Amount,
            ExpirationDate = ep.ExpiryDate
        }).ToList();
        
        return new GetExpiringPointsQueryResponse
        {
            ExpiringPoints = result
        };
    }
}

