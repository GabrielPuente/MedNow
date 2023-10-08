using MedNow.Domain.Entities;
using MedNow.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedNow.Infra.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.AddAuditProperties();
            builder.AddSoftDeleteProperties();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(x => x.Name).IsRequired().HasVarchar(100);
            builder.Property(x => x.Role).IsRequired().HasVarchar(100);
            builder.Property(x => x.Cpf).IsRequired().HasVarchar(15);
            builder.Property(x => x.Password).IsRequired().HasVarchar(500);
            builder.Property(x => x.Email).IsRequired().HasVarchar(100);
            builder.Property(x => x.BirthDate).IsRequired();

            builder.OwnsOne(x => x.Address, y =>
            {
                y.ToTable("Address");

                y.HasKey(x => x.UserId);
                y.WithOwner().HasForeignKey(x => x.UserId);

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

                y.HasKey(x => x.UserId);
                y.WithOwner().HasForeignKey(x => x.UserId);

                y.Property(x => x.Number).IsRequired();
                y.Property(x => x.Name).HasVarchar(150).IsRequired();
                y.Property(x => x.ExpirationDate).IsRequired();
                y.Property(x => x.Cvv).IsRequired();
            });

            builder.HasIndex(x => x.Email);
        }
    }
}
