using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Mappings
{
    public class ProductBrandMap : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable("product_brand");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR").HasMaxLength(25).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
        }
    }
}