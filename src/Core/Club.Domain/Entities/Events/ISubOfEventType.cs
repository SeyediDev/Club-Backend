namespace Club.Domain.Entities.Events;

public interface ISubOfEventType
{
    int EventTypeId { get; set; }
    EventType EventType { get; set; }
}
