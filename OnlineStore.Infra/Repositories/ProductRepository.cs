using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Context;

namespace OnlineStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _context.Set<Product>().Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync(x => x.Id == id);

            return product;
        }
    }
}