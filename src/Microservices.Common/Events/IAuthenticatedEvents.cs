namespace Microservices.Common.Events
{
    public interface IAuthenticatedEvents : IEvent
    {
        Guid UserId { get; }
    }
}
