using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Mappings;

namespace OnlineStore.Infra.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(
            $"Server={Environment.GetEnvironmentVariable("DB_SERVER")},1433;Database={Environment.GetEnvironmentVariable("DB_SCHEMA")};User ID={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};TrustServerCertificate={Environment.GetEnvironmentVariable("TRUST_SERVER_CERTIFICATE")}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductBrandMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
        }
    }
}
