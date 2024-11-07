﻿
using Microservices.Services.Activities.Domain.Models;
using Microservices.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Microservices.Services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task<Category> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);



        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");

    }

}
