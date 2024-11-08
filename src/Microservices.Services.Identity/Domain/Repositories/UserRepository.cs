using Microservices.Services.Identity.Domain.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Microservices.Services.Identity.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger _logger;

        public UserRepository(IMongoDatabase database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<User> GetAsync(Guid id)
           => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);


        public async Task<User> GetAsync(string email)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());



        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user);

        private IMongoCollection<User> Collection
            => _database.GetCollection<User>("Users");
    }
}
