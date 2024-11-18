using Microservices.Api.Models;
using Microservices.Api.Repositories;
using Microservices.Common.Events;

namespace Microservices.Api.handlers
{
    public class ActivityCreatedhandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityCreatedhandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public async Task HandleAsync(ActivityCreated @event)
        {
            await _activityRepository.AddAsync(new Activity
            {
                Id = @event.Id,
                UserId = @event.UserId,
                Category = @event.Category,
                Name = @event.Name,
                Description = @event.Description,
                CreatedAt = @event.CreatedAt
            });
        }
    }
}
