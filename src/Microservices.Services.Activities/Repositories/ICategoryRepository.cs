using Microservices.Services.Activities.Domain.Models;

namespace Microservices.Services.Activities.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(Guid id);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);
    }
}
