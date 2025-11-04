using Club.CustomerPortal.Application.Interfaces;

namespace Club.CustomerPortal.Application.Services;

public class MockPromotionService : IPromotionService
{
    public Task<PaginatedList<PromotionDto>> GetActivePromotionsAsync(int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var promotions = new List<PromotionDto>
        {
            new() { Id = 1, Title = "جشنواره تابستانی", Description = "50% تخفیف ویژه", StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(25), ImageUrl = null, IsActive = true, CanParticipate = true }
        };

        return Task.FromResult(new PaginatedList<PromotionDto>(promotions, 1, pageNumber, pageSize));
    }

    public Task<PromotionDto?> GetPromotionByIdAsync(int promotionId, CancellationToken cancellationToken = default)
    {
        var promotion = new PromotionDto
        {
            Id = promotionId,
            Title = "جشنواره تابستانی",
            Description = "50% تخفیف ویژه تابستان",
            StartDate = DateTime.Now.AddDays(-5),
            EndDate = DateTime.Now.AddDays(25),
            ImageUrl = null,
            IsActive = true,
            CanParticipate = true
        };

        return Task.FromResult<PromotionDto?>(promotion);
    }

    public Task<ParticipationResultDto> ParticipateAsync(int customerId, int promotionId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new ParticipationResultDto
        {
            Success = true,
            Message = "شما با موفقیت در کمپین شرکت کردید"
        });
    }

    public Task<PaginatedList<MyParticipationDto>> GetMyParticipationsAsync(int customerId, int pageNumber = 1, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var participations = new List<MyParticipationDto>();
        return Task.FromResult(new PaginatedList<MyParticipationDto>(participations, 0, pageNumber, pageSize));
    }
}

