using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.ValueObjects;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnName("Name");

            builder.Property(x => x.Description)
                .HasColumnName("Desciption");

            builder.Property(x => x.Price)
                .HasColumnName("Price");

            builder.Property(x => x.Category)
                .HasColumnName("Category")
                .HasConversion(
                    x => x.Text,
                    text => new Category(text)
                ).IsRequired(); 

            builder.Property(x => x.Color)
                .HasColumnName("Color")
                .HasConversion(
                    x => x.Text,
                    text => new Color(text)
                ).IsRequired();

            builder.Property(x => x.Size)
                .HasColumnName("Size")
                .HasConversion(
                    x => x.Text,
                    text => new Size(text)
                ).IsRequired();
        }
    }
}
