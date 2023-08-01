using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newme.Purchase.Infrastructure.Configurations.Utils;

namespace Newme.Purchase.Infrastructure.Persistence.Configurations
{
    public static class StatusBaseConfiguration
    {
        public static EntityTypeBuilder<TStatus> ConfigureStatus<TStatus, TEnum>(this EntityTypeBuilder<TStatus> builder) 
            where TStatus : StatusBase<TEnum>
            where TEnum : Enum
        {
            builder.UseTpcMappingStrategy();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(x => x.Status)
                .HasColumnName("Status");
                
            builder.Property(x => x.Description)
                .HasColumnName("Description");

            builder.HasIndex(x => x.Status);

            return builder;
        }
    }
}