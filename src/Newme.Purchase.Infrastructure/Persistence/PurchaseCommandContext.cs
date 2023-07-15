using Microsoft.EntityFrameworkCore;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Infrastructure.Configurations.Utils;
using Newme.Purchase.Infrastructure.Persistence.Configurations;

namespace Newme.Purchase.Infrastructure.Persistence
{
    public class PurchaseCommandContext: DbContext
    {
        public PurchaseCommandContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<PurchaseOrderState> PurchaseOrderStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseItemConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseOrderStateConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}