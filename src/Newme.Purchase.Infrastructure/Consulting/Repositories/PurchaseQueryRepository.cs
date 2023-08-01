using MongoDB.Driver;
using Newme.Purchase.Application.Consulting.ConsultingModels;
using Newme.Purchase.Application.Consulting.Repositories;

namespace Newme.Purchase.Infrastructure.Consulting.Repositories
{
    public class PurchaseQueryRepository : BaseQueryRepository<PurchaseConsultingModel>, IPurchaseQueryRepository
    {
        private readonly IMongoDatabase _database;
        public PurchaseQueryRepository(IMongoDatabase database) 
            : base(database, "purchase")
        {
            _database = database;
        }

        public async Task<IList<PurchaseConsultingModel>> GetAllBuyersPurchase(Guid buyerId)
        {
            return await _collection.Find(c => c.Buyer.Id == buyerId).ToListAsync();
        }

        public async Task UpdateItemsAsync(IList<PurchaseItemConsultingModel> items) 
        {
            var collection = _database.GetCollection<PurchaseItemConsultingModel>("purchase-item-consulting-model");

            var models = new WriteModel<PurchaseItemConsultingModel>[items.Count];

            var index = 0;
            foreach (var item in items)
            {
                var filter = Builders<PurchaseItemConsultingModel>.Filter
                    .Where(x => x.PurchaseId == item.PurchaseId && x.ProductId == item.ProductId);

                models[index] = new ReplaceOneModel<PurchaseItemConsultingModel>(
                    filter, item
                );
                index += 1;
            }

            await collection.BulkWriteAsync(models);
        }
    }
}
