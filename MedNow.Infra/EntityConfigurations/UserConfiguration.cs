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

            builder.HasIndex(x => x.Email);
        }
    }
}
