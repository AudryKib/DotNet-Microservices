namespace Microservices.Common.Events
{
    internal interface IEventhandler<in T> where T : IEvents
    {
        Task HandleAsync(T @event);
    }
}
