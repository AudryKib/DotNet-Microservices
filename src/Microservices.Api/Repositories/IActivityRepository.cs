using Microservices.Api.Models;

namespace Microservices.Api.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
        Task<IEnumerable<Activity>> BrowseAsync(Guid userId);
    }
}