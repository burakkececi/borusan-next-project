using System;
using Newtonsoft.Json;

namespace Common.Models;
public class OutboxEvent
{
    protected OutboxEvent() { }
    public OutboxEvent(object message, Guid eventId, DateTime occuredOn)
    {
        Payload = JsonConvert.SerializeObject(message);
        Type = message.GetType().FullName + ", " +
               message.GetType().Assembly.GetName().Name;
        EventId = eventId;
        OccuredOn = occuredOn;
        State = OutboxEventState.ReadyToSend;
    }
    public long Id { get; protected set; }
    public Guid EventId { get; protected set; }
    public DateTime OccuredOn { get; set; }
    public string Payload { get; protected set; }
    public string @Type { get; protected set; }
    public OutboxEventState State { get; private set; }
    public DateTime? ProcessedDate { get; set; }

    public void ChangeState(OutboxEventState state)
    {
        State = state;
        ProcessedDate = DateTime.Now.ToUniversalTime();
    }

    public object RecreateMessage() =>
            JsonConvert.DeserializeObject(Payload, System.Type.GetType(Type)!)!;
}
