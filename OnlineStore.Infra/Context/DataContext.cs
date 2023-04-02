using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Mappings;

namespace OnlineStore.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=OnlineStore;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductBrandMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
        }
    }
}
