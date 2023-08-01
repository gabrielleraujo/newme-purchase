using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Infrastructure.Configurations.Utils;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class PurchaseOrderStatusConfiguration : IEntityTypeConfiguration<PurchaseOrderStatus>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderStatus> builder)
        {
            builder.ToTable("PurchaseOrderStatus");

            builder
                .ConfigureStatus<PurchaseOrderStatus, EPurchaseOrderStatus>()
                .HasData(PurchaseOrderStatus.Data);
        }
    }
}
