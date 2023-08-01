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

        public async Task<PurchaseOrder> FindIncludingByAsync(Func<PurchaseOrder, bool> predicate)
        {
            var response = _context.Purchases
                .Include(x => x.PurchaseItems)
                .Where(predicate)
                .FirstOrDefault();
            
            return await Task.FromResult(response);
        }

        public async Task UpdateStatusAsync(PurchaseOrder purchase)
        {
            var dbSet = _context.Purchases;
            var affectedRows = await dbSet
                .Where(x => x.Id == purchase.Id)
                .ExecuteUpdateAsync(x =>
                    x.SetProperty(x => x.Status, x => purchase.Status)
                );

            VerifyUpdateStatus(affectedRows);
        }

        public async Task UpdateItemStatusAsync(PurchaseItem purchaseItem)
        {
            var dbSet = _context.PurchaseItems;
            var affectedRows = await dbSet
                .Where(x => x.Id == purchaseItem.Id)
                .ExecuteUpdateAsync(x =>
                    x.SetProperty(x => x.Status, x => purchaseItem.Status)
                );
            VerifyUpdateStatus(affectedRows);
        }

        private static void VerifyUpdateStatus(int affectedRows)
        {
            if (affectedRows == 0) 
                throw new DbUpdateException("Error updating purchase status");
        }
    }
}