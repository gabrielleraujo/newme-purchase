using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Infrastructure.Configurations.Utils;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class PurchaseOrderItemStatusConfiguration : IEntityTypeConfiguration<PurchaseOrderItemStatus>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderItemStatus> builder)
        {
            builder.ToTable("PurchaseOrderItemStatus");

            builder
                .ConfigureStatus<PurchaseOrderItemStatus, EPurchaseOrderItemStatus>()
                .HasData(PurchaseOrderItemStatus.Data);
        }
    }
}
