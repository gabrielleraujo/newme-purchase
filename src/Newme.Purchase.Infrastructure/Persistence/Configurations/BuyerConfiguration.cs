using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Entities;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.ToTable("Buyers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.Surname)
                .HasColumnName("Surname");

            builder.Property(x => x.Email)
                .HasColumnName("Email");

            builder.Property(x => x.Username)
                .HasColumnName("Username");
        }
    }
}