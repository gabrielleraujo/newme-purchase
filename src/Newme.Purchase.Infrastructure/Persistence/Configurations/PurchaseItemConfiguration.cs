using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class PurchaseItemConfiguration : IEntityTypeConfiguration<PurchaseItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseItem> builder)
        {
            builder.ToTable("PurchaseOrderItem");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(x => x.PurchaseOrderId)
                .HasColumnName("PurchaseOrderId");

            builder.Property(x => x.ProductId)
                .HasColumnName("ProductId");
            builder.HasOne<Product>();

            builder.Property(x => x.UnitPrice)
                .HasColumnName("UnitPrice");

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity");
        }
    }
}