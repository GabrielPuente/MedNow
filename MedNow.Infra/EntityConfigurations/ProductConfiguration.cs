using MedNow.Domain.Entities;
using MedNow.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedNow.Infra.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.AddAuditProperties();
            builder.AddSoftDeleteProperties();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(x => x.Name).IsRequired().HasVarchar(100);
            builder.Property(x => x.Price).IsRequired().HasDecimalPrecision();
            builder.Property(x => x.PromotionalPrice).IsRequired(false).HasDecimalPrecision();
            builder.Property(x => x.ImagePath).IsRequired().HasVarchar(150);
            builder.Property(x => x.Description).IsRequired().HasVarchar(500);
        }
    }
}
