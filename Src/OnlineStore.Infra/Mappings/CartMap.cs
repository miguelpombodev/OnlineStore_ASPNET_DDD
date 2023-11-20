using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Models;

namespace OnlineStore.Infra.Mappings
{
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("carts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("UniqueIdentifier");
            builder.Property(x => x.CustomerId).HasColumnName("customer_id").HasColumnType("UniqueIdentifier");
            builder.Property(x => x.Purchased).HasColumnName("purchased").HasColumnType("BIT");
        }
    }
}