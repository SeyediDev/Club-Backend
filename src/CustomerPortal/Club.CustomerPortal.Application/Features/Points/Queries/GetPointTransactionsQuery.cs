namespace Club.CustomerPortal.Application.Features.Points.Queries;

public record GetPointTransactionsQuery : IRequest<GetPointTransactionsQueryResponse>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? PointTypeId { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public record GetPointTransactionsQueryResponse
{
    public PaginatedList<PointTransactionDto> Transactions { get; set; } = null!;
}

public record PointTransactionDto
{
    public string Id { get; set; } = null!;
    public DateTime TransactionDate { get; set; }
    public string PointTypeName { get; set; } = null!;
    public string PointTypeColor { get; set; } = null!;
    public int Amount { get; set; }
    public string TransactionType { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ReferenceId { get; set; }
    public string? ReferenceType { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string Status { get; set; } = null!;
}

public class GetPointTransactionsQueryHandler : IRequestHandler<GetPointTransactionsQuery, GetPointTransactionsQueryResponse>
{
    private readonly IPointService _pointService;
    private readonly IRequesterUser _requesterUser;

    public GetPointTransactionsQueryHandler(
        IPointService pointService,
        IRequesterUser requesterUser)
    {
        _pointService = pointService;
        _requesterUser = requesterUser;
    }

    public async Task<GetPointTransactionsQueryResponse> Handle(GetPointTransactionsQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        var result = await _pointService.GetPointTransactionsAsync(
            customerId,
            request.PageNumber,
            request.PageSize,
            cancellationToken);
        
        // تبدیل PagedResult به PaginatedList
        var transactions = result.Items.Select(t => new PointTransactionDto
        {
            Id = t.Id.ToString(),
            TransactionDate = t.CreatedAt,
            PointTypeName = "امتیاز طلایی", // TODO: باید از database بگیریم
            PointTypeColor = "#FFD700",
            Amount = (int)t.Amount,
            TransactionType = t.Type,
            Description = t.Description ?? t.Title,
            ReferenceId = null,
            ReferenceType = null,
            ExpirationDate = null,
            Status = "Completed"
        }).ToList();
        
        return new GetPointTransactionsQueryResponse
        {
            Transactions = new PaginatedList<PointTransactionDto>(
                transactions,
                result.TotalCount,
                request.PageNumber,
                request.PageSize)
        };
    }
}

