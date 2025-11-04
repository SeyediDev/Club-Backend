using Neo.Domain.Features.Multilingual;
using Club.Domain.Enums;
using Club.Domain.Features.ScoringRules;

namespace Club.Channel.Application.Features.Client.Commands;

public record EventCommand : IRequest
{
    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    public string CustomerMobile { get; set; } = null!;
    public string EventType { get; set; } = null!;
    public string EventChannel { get; set; } = null!;
    public Dictionary<string, string>? Parameters { get; set; }
}

public class EventCommandValidator : AbstractValidator<EventCommand>
{
    public EventCommandValidator(IMultiLingualService multiLingual)
    {
    }
}

public class EventCommandHandler(
    IEventService eventLogService, IScoringRuleService scoringRuleService
    ) : IRequestHandler<EventCommand>
{
    public async Task Handle(EventCommand request, CancellationToken cancellationToken)
    {
        var eventRequest = new EventRequest(
            TriggerType.Event,
            request.CustomerMobile, // شماره موبایل
            request.Parameters)
        {
            EventChannel = request.EventChannel,
            EventType = request.EventType
        };
        EventResponse? eventResponse = await eventLogService.RecordEventAsync(eventRequest, cancellationToken);
        if (eventResponse != null)
        {
            await scoringRuleService.ScoringAnalysis(
                new(TriggerType.Event, eventResponse.Customer, eventResponse.EventLogId, request.Parameters)
                {
                    EventChannelId = eventResponse.EventChannelId,
                    EventTypeId = eventResponse.EventTypeId
                }, cancellationToken);
        }
    }
}
