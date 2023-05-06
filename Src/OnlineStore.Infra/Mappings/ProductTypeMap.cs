using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Mappings
{
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {

            builder.ToTable("product_type");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("NVARCHAR").HasMaxLength(40).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
        }
    }
}