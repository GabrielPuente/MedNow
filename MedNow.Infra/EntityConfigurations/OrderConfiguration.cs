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

            builder.Property(x => x.TotalValue).IsRequired().HasDecimalPrecision();

            builder.OwnsOne(x => x.Address, y =>
            {
                y.ToTable("Address");

                y.HasKey(x => x.OrderId);
                y.WithOwner().HasForeignKey(x => x.OrderId);

                y.Property(x => x.ZipCode).HasVarchar(9).IsRequired();
                y.Property(x => x.Street).HasVarchar(150).IsRequired();
                y.Property(x => x.Number).IsRequired();
                y.Property(x => x.Neighborhood).IsRequired().HasVarchar(100);
                y.Property(x => x.City).IsRequired().HasVarchar(100);
                y.Property(x => x.State).IsRequired().HasVarchar(50);
            });

            builder.OwnsOne(x => x.CreditCard, y =>
            {
                y.ToTable("CreditCard");

                y.HasKey(x => x.OrderId);
                y.WithOwner().HasForeignKey(x => x.OrderId);

                y.Property(x => x.Number).IsRequired();
                y.Property(x => x.Name).HasVarchar(150).IsRequired();
                y.Property(x => x.ExpirationDate).IsRequired();
                y.Property(x => x.Cvv).IsRequired();
            });

            builder.OwnsMany(x => x.OrderItems, x =>
            {
                x.ToTable("OrderItem");

                x.HasKey(x => x.Id);
                x.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

                x.HasOne(x => x.Product);

                x.Property(x => x.Quantity).IsRequired();
                x.Property(x => x.TotalValue).IsRequired().HasDecimalPrecision();

                x.WithOwner().HasForeignKey("OrderId");
            });
        }
    }
}
