using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.Enums;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("PurchaseOrder");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(x => x.BuyerId)
                 .HasColumnName("BuyerId");

            builder.Property(x => x.Price)
                 .HasColumnName("Price");

            builder.Property(x => x.Date)
                 .HasColumnName("Date");

            builder.Property(x => x.FreightValue)
                 .HasColumnName("FreightValue");


            builder.Property(x => x.HasDiscountCoupon)
                 .HasColumnName("HasDiscountCoupon");

            builder.Property(x => x.DiscountCouponId)
                 .HasColumnName("DiscountCouponId");


            builder.OwnsOne(x => x.Address, y =>
            {
                y.Property(y => y.Street)
                    .HasColumnName("Street");

                y.Property(y => y.ZipCode)
                    .HasColumnName("ZipCode");

                y.Property(y => y.UF)
                    .HasColumnName("UF");

                y.Property(y => y.City)
                    .HasColumnName("City");

                y.Property(y => y.Neighborhood)
                   .HasColumnName("Neighborhood");

                y.Property(y => y.Number)
                    .HasColumnName("Number");

                y.Property(y => y.Complement)
                    .HasColumnName("Complement");
            });


            builder.Property(x => x.State)
                .HasColumnName("State")
                .ValueGeneratedNever()
                .IsRequired()
                .HasDefaultValue(EPurchaseOrderState.Initial);


            builder.HasOne(x => x.Buyer);
            builder.HasMany(x => x.PurchaseItems);

            //builder.Ignore(x => x.PurchaseItems);
        }
    }
}