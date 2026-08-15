using Neo.Application.Features.Outbox.Dto;

namespace Club.Channel.Api.Controllers.Dto;

public sealed record OutboxResponseDto(long OutboxId, string State, string? JobId, string? IdempotencyKey)
{
    public OutboxResponseDto(OutboxResponse response)
        : this(
            response.OutboxId,
            response.OutboxState.ToString(),
            response.JobId,
            response.IdempotencyKey)
    {
    }
}