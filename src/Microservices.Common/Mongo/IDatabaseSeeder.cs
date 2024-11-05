namespace Microservices.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
