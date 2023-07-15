using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Enums;
using Newme.Purchase.Infrastructure.Configurations.Utils;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class PurchaseOrderStateConfiguration : IEntityTypeConfiguration<PurchaseOrderState>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderState> builder)
        {
            builder.ToTable("PurchaseOrderState");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(x => x.State)
                .HasColumnName("State");
                
            builder.Property(x => x.Description)
                .HasColumnName("Description");

            builder.HasIndex(x => x.State);

            builder.HasData(new List<PurchaseOrderState>()
            {
                new(EPurchaseOrderState.Initial),
                new(EPurchaseOrderState.PaymentValidation),
                new(EPurchaseOrderState.PaymentAuthorized),
                new(EPurchaseOrderState.PaymentUnauthorized),
                new(EPurchaseOrderState.OutOfStock),
                new(EPurchaseOrderState.PartiallyApproved),
                new(EPurchaseOrderState.Approved)
            });
        }
    }
}