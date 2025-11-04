using Neo.Domain.Features.Multilingual;

namespace Club.Application.Features.Club.Commands;

public record PurchaseAwardCommand : IRequest<PurchaseAwardCommandResponse>
{
    public string CustomerId { get; set; } = null!;
    public int AwardId { get; set; }
}
public record PurchaseAwardCommandResponse
{
    public string CustomerId { get; set; } = null!;
    public int AwardId { get; set; }
}

public class PurchaseAwardCommandValidator : AbstractValidator<PurchaseAwardCommand>
{
    public PurchaseAwardCommandValidator(IMultiLingualService multiLingual)
    {
    }
}

public class PurchaseAwardCommandHandler(IAwardAssetService awardAssetService)
    : IRequestHandler<PurchaseAwardCommand, PurchaseAwardCommandResponse>
{
    public async Task<PurchaseAwardCommandResponse> Handle(PurchaseAwardCommand request, CancellationToken cancellationToken)
    {
        PurchaseAwardResponse response = await awardAssetService.PurchaseAward(
            new()
            { 
                Customer= request.CustomerId, 
                AwardId= request.AwardId 
            }, cancellationToken);
        return response.Adapt<PurchaseAwardCommandResponse>();
    }
}
