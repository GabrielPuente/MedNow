using MedNow.Domain.Entities;
using MedNow.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedNow.Infra.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.AddAuditProperties();
            builder.AddSoftDeleteProperties();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.HasOne(x => x.User);

            builder.OwnsMany(
                       x => x.OrderItems,
                       x =>
                       {
                           x.ToTable("OrderItem");

                           x.HasKey(x => x.Id);
                           x.Property(x => x.Id)
                            .ValueGeneratedNever()
                            .IsRequired();

                           x.HasOne(x => x.Product);

                           x.Property(x => x.Quantity).IsRequired();

                           x.WithOwner().HasForeignKey("OrderId");
                       });
        }
    }
}
