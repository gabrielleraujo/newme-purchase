using Microsoft.EntityFrameworkCore;
using Newme.Purchase.Domain.Models.Abstracts;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Domain.Repositories;

namespace Newme.Purchase.Infrastructure.Persistence.Repositories
{
    public class PurchaseCommandRepository : BaseCommandRepository<PurchaseOrder>, IPurchaseCommandRepository
    {
        public PurchaseCommandRepository(PurchaseCommandContext dbContext) : base(dbContext)
        {
        }

        public async Task AddBuyerAsync(Buyer buyer)
        {
            await _context.Buyers.AddAsync(buyer);
        }

        public async Task AddRangeProductsAsync(IEnumerable<Product> products)
        {
            await _context.Products.AddRangeAsync(products);
        }

        public async Task<bool> UpdateStateAsync(Guid id, EPurchaseOrderState newState)
        {
            var dbSet = _context.Purchases;
            var affectedRows = await dbSet
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x =>
                    x.SetProperty(x => x.State, x => newState)
                );
            return affectedRows > 0;
        }

        public async Task<PurchaseOrder> FindIncludingByAsync(Func<PurchaseOrder, bool> predicate)
        {
            var response = _context.Purchases
                .Include(x => x.PurchaseItems)
                .Where(predicate)
                .FirstOrDefault();
            
            return await Task.FromResult(response);
        }
    }
}