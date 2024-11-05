using MongoDB.Driver;

namespace Microservices.Common.Mongo
{

    /// <summary>
    /// Default implementation of a custom seeder.
    /// </summary>
    public class MongoSeeder : IDatabaseSeeder
    {
        protected readonly IMongoDatabase Database;

        public MongoSeeder(IMongoDatabase database)
        {
            Database = database;
        }

        public async Task SeedAsync()
        {
            var collectionCursor = await Database.ListCollectionsAsync();
            var collections = await collectionCursor.ToListAsync();
            if (collections.Any())
            {
                return;
            }
            await CustomSeedAsync();
        }

        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask; // Default implementation - does nothing. See CustomMongoSeeder for actual job.
        }
    }
}
