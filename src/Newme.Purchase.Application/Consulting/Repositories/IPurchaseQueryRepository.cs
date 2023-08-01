using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Application.Consulting.Repositories
{
    public interface IPurchaseQueryRepository : IBaseQueryRepository<PurchaseConsultingModel>
    {
        Task<IList<PurchaseConsultingModel>> GetAllBuyersPurchase(Guid buyerId);
        Task UpdateItemsAsync(IList<PurchaseItemConsultingModel> items);
    }
}
