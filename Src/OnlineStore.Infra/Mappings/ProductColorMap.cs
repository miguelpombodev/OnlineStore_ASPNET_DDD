using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Mappings
{
    public class ProductColorMap : IEntityTypeConfiguration<ProductColors>
    {
        public void Configure(EntityTypeBuilder<ProductColors> builder)
        {

            builder.ToTable("product_colors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("UniqueIdentifier");
            builder.Property(x => x.ProductId).HasColumnName("product_id").HasColumnType("UniqueIdentifier").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR").HasMaxLength(25).IsRequired();
            builder.Property(x => x.ProductColorURL).HasColumnName("product_color_URL").HasColumnType("NVARCHAR").HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
        }
    }
}