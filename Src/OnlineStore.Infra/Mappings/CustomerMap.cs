using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("UniqueIdentifier");
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("NVARCHAR").HasMaxLength(15).IsRequired();
            builder.Property(x => x.Surname).HasColumnName("surname").HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CPF).HasColumnName("CPF").HasColumnType("VARCHAR").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Cellphone).HasColumnName("cellphone").HasColumnType("NVARCHAR").HasMaxLength(12).IsRequired();
            builder.Property(x => x.Sex).HasColumnName("sex").HasColumnType("CHAR").HasMaxLength(1).IsRequired();
            builder.Property(x => x.Password).HasColumnName("password").HasColumnType("NVARCHAR").HasMaxLength(64).IsRequired();
            builder.Property(x => x.BirthDate).HasColumnName("birthdate").HasColumnType("DATETIME");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.HasIndex(x => x.CPF, "IX_CUSTOMERS_CPF").IsUnique();
            builder.HasIndex(x => x.Email, "IX_CUSTOMERS_EMAIL").IsUnique();
        }
    }
}