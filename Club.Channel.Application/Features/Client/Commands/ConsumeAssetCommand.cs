using Neo.Domain.Features.Multilingual;

namespace Club.Channel.Application.Features.Client.Commands;

public record ConsumeAssetCommand : IRequest<ConsumeAssetCommandResponse>
{
    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    public string CustomerMobile { get; set; } = null!;
    public string Serial { get; set; } = null!;
}

public record ConsumeAssetCommandResponse
{
    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    public string CustomerMobile { get; set; } = null!;
    public string Serial { get; set; } = null!;
}

public class ConsumeAssetCommandValidator : AbstractValidator<ConsumeAssetCommand>
{
    public ConsumeAssetCommandValidator(IMultiLingualService multiLingual)
    {
    }
}

public class ConsumeAwardCommandHandler(IAwardAssetService awardAssetService)
    : IRequestHandler<ConsumeAwardCommand, ConsumeAwardCommandResponse>
{
    public async Task<ConsumeAwardCommandResponse> Handle(ConsumeAwardCommand request, CancellationToken cancellationToken)
    {
        ConsumeAccetResponse response = await awardAssetService.ConsumeAward(new()
            {
                Customer = request.CustomerMobile,
                Serial = request.Serial,
            }, cancellationToken);
        return response.Adapt<ConsumeAwardCommandResponse>();
    }
}

// Legacy support - will be removed
public class ConsumeAssetCommandHandler(IAwardAssetService awardAssetService)
    : IRequestHandler<ConsumeAssetCommand, ConsumeAssetCommandResponse>
{
    public async Task<ConsumeAssetCommandResponse> Handle(ConsumeAssetCommand request, CancellationToken cancellationToken)
    {
        ConsumeAccetResponse response = await awardAssetService.ConsumeAward(new()
            {
                Customer = request.CustomerMobile,
                Serial = request.Serial,
            }, cancellationToken);
        return response.Adapt<ConsumeAssetCommandResponse>();
    }
}

public record ConsumeAwardCommand : IRequest<ConsumeAwardCommandResponse>
{
    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    public string CustomerMobile { get; set; } = null!;
    public string Serial { get; set; } = null!;
}

public record ConsumeAwardCommandResponse
{
    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    public string CustomerMobile { get; set; } = null!;
    public string Serial { get; set; } = null!;
}

public class ConsumeAwardCommandValidator : AbstractValidator<ConsumeAwardCommand>
{
    public ConsumeAwardCommandValidator(IMultiLingualService multiLingual)
    {
    }
}
