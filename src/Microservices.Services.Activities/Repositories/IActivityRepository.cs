using Microservices.Services.Activities.Domain.Models;

namespace Microservices.Services.Activities.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
    }
}