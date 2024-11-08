

using Microservices.Common.Exceptions;
using Microservices.Services.Activities.Domain.Models;
using Microservices.Services.Activities.Domain.Repositories;
using Microservices.Services.Activities.Services;

namespace Actio.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(category);
            if (activityCategory == null)
            {
                throw new MicroException("category_not_found", $"Category: '{category}' was not found.");
            }
            await _activityRepository.AddAsync(
                new Activity(id, activityCategory, userId, name, description, createdAt)
            );
        }
    }
}