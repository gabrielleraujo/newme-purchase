using Newme.Purchase.Infrastructure.Consulting.ConsultingModels;

namespace Newme.Purchase.Infrastructure.Consulting.Repositories
{
    public interface IPurchaseQueryRepository : IBaseQueryRepository<PurchaseConsultingModel>
    {
		Task<IList<PurchaseConsultingModel>> GetAllBuyersPurchase(Guid buyerId);
    }
}
