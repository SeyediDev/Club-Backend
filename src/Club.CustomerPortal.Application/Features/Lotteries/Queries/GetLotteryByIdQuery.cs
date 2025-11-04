namespace Club.CustomerPortal.Application.Features.Lotteries.Queries;

public record GetLotteryByIdQuery : IRequest<GetLotteryByIdQueryResponse>
{
    public string Id { get; set; } = null!;
}

public record GetLotteryByIdQueryResponse
{
    public LotteryDto Lottery { get; set; } = null!;
}

public class GetLotteryByIdQueryHandler : IRequestHandler<GetLotteryByIdQuery, GetLotteryByIdQueryResponse>
{
    private readonly ILotteryService _lotteryService;

    public GetLotteryByIdQueryHandler(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }

    public async Task<GetLotteryByIdQueryResponse> Handle(GetLotteryByIdQuery request, CancellationToken cancellationToken)
    {
        var lottery = await _lotteryService.GetLotteryByIdAsync(int.Parse(request.Id), cancellationToken);
        
        if (lottery == null)
        {
            throw new InvalidOperationException("قرعه‌کشی یافت نشد");
        }
        
        return new GetLotteryByIdQueryResponse
        {
            Lottery = new LotteryDto
            {
                Id = lottery.Id.ToString(),
                Name = lottery.Title,
                Description = lottery.Description ?? string.Empty,
                ImageUrl = null,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
                DrawDate = lottery.DrawDate,
                IsActive = lottery.IsActive,
                EntryCost = null,
                MaxEntries = lottery.MaxParticipants,
                MyEntries = 0,
                TotalEntries = lottery.CurrentParticipants,
                Prizes = [],
                HasParticipated = lottery.HasDrawn,
                IsWinner = null
            }
        };
    }
}

