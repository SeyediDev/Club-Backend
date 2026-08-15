using Club.Channel.Application.Features.Channel.Commands;

namespace Club.Channel.Api.Controllers.Dto.Events;

public sealed record BulkReceiveDynamicEventResponseDto
{
    public List<OutboxResponseDto> Results { get; init; } = [];

    public BulkReceiveDynamicEventResponseDto(BulkOutboxResponse response)
    {
        Results = [.. response.Results.Select(r => new OutboxResponseDto(r))];
    }
}