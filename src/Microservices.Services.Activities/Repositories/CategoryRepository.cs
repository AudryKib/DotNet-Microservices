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
        public async Task<Category> GetAsync(string name)
             => await Collection
                 .AsQueryable()
                 .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant()); // <= MongoDB.Driver.Linq


        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);



        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");

    }

}
