using System.Linq.Expressions;
using MongoDB.Driver;
using Newme.Purchase.Infrastructure.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Repositories
{
    public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : ConsultingModel
    {
        protected readonly IMongoCollection<T> _collection;
        public BaseQueryRepository(IMongoDatabase database, String collection)
        {
            _collection = database.GetCollection<T>(collection);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task AddAsync(T value) 
        {
            await _collection.InsertOneAsync(value);
        }

        public async Task UpdateAsync<TValueUpdate>(
            Guid id, TValueUpdate newValue, Expression<Func<T, TValueUpdate>> expression) 
        {
            var filter = Builders<T>.Filter
                .Eq(restaurant => restaurant.Id, id);
                
            var update = Builders<T>.Update
                .Set<TValueUpdate>(expression, newValue);

            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
