using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Configuration;
using OnlineStore.Infra.Mappings;

namespace OnlineStore.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(AppConfiguration.MainDatabaseConnectionString);
            options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductBrandMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new ProductColorMap());
            modelBuilder.ApplyConfiguration(new CartMap());
        }
    }
}
