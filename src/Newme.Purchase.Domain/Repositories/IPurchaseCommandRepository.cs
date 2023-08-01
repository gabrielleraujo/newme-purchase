using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Domain.Repositories
{
    public interface IPurchaseCommandRepository : IBaseCommandRepository<PurchaseOrder>
    {
        Task AddBuyerAsync(Buyer buyer);
        Task AddRangeProductsAsync(IEnumerable<Product> products);

        Task UpdateStatusAsync(PurchaseOrder purchase);
        Task UpdateItemStatusAsync(PurchaseItem purchaseItem);

        // Task<bool> UpdateStatusAsync(Guid id, EPurchaseOrderStatus newState);
        // Task<bool> UpdateItemStatusAsync(Guid id, EPurchaseOrderItemStatus newState);
        Task<PurchaseOrder> FindIncludingByAsync(Func<PurchaseOrder, bool> predicate);
    }
}