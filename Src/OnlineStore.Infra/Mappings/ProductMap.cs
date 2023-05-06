using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("UniqueIdentifier");
            builder.Property(x => x.TypeId).HasColumnName("type_id").HasColumnType("INT").IsRequired();
            builder.Property(x => x.BrandId).HasColumnName("brand_id").HasColumnType("INT").IsRequired();
            builder.Property(x => x.Sku).HasColumnName("sku").HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR").HasMaxLength(255).IsRequired();
            builder.Property(x => x.StockAmount).HasColumnName("stock_amount").HasColumnType("INT").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder.HasIndex(x => x.Sku, "IX_PRODUCTS_SKU").IsUnique();

            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasConstraintName("FK_PROD_BRANDID").HasForeignKey(f => f.BrandId);
            builder.HasOne(x => x.Type).WithMany(x => x.Products).HasConstraintName("FK_PROD_PRODTYPE").HasForeignKey(f => f.TypeId);

        }
    }
}