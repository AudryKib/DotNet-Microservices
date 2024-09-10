namespace Microservices.Common.Events
{
    public interface IAuthenticatedEvents : IEvents
    {
        Guid UserId { get; }
    }
}
