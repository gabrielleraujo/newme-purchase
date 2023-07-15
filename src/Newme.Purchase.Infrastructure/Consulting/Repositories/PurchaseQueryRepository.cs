using MongoDB.Driver;
using Newme.Purchase.Infrastructure.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Repositories
{
    public class PurchaseQueryRepository : BaseQueryRepository<PurchaseConsultingModel>, IPurchaseQueryRepository
    {
        public PurchaseQueryRepository(IMongoDatabase database) 
            : base(database, "purchase")
        {
            
        }

        public async Task<IList<PurchaseConsultingModel>> GetAllBuyersPurchase(Guid buyerId)
        {
            return await _collection.Find(c => c.Buyer.Id == buyerId).ToListAsync();
        }
    }
}
