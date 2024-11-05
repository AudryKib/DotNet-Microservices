using Microservices.Common.Events;

namespace Microservices.Api.handlers
{
    public class ActivityCreatedhandler : IEventHandler<ActivityCreated>
    {
        public async Task HandleAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Booyahh the Activity is created: {@event.Name}");
        }
    }
}
