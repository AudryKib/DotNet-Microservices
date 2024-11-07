using Microservices.Common.Mongo;
using Microservices.Services.Activities.Domain.Models;
using Microservices.Services.Activities.Domain.Repositories;
using MongoDB.Driver;

namespace Microservices.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;
        public CustomMongoSeeder(IMongoDatabase database, ICategoryRepository categoryRepository)
            : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
           {
               "work",
               "sport",
               "hobby"
           };

            Console.WriteLine("Seeding categories...");

            await Task.WhenAll(categories.Select(x => _categoryRepository.AddAsync(new Category(x))));
        }
    }
}
