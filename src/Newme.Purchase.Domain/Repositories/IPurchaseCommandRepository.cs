using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.Enums;

namespace Newme.Purchase.Domain.Repositories
{
    public interface IPurchaseCommandRepository : IBaseCommandRepository<PurchaseOrder>
    {
        Task AddBuyerAsync(Buyer buyer);
        Task AddRangeProductsAsync(IEnumerable<Product> products);
        Task<bool> UpdateStateAsync(Guid id, EPurchaseOrderState newState);
        Task<PurchaseOrder> FindIncludingByAsync(Func<PurchaseOrder, bool> predicate);
    }
}