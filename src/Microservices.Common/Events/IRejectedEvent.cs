namespace Microservices.Common.Events
{
    public interface IRejectedEvent : IEvents
    {
        string Reason { get; }
        string Code { get; }
    }
}
