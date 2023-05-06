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
            try
            {
                var product = await _context.Set<Product>().Include(p => p.Brand).Include(p => p.Type).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                return product;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.ToString());
            }
        }

        public async Task<List<Product>> GetAllProducts(
            int? type_id,
            int? brand_id,
            decimal? priceStarts,
            decimal? priceEnds,
            string? orderBy
        )
        {
            try
            {
                var productListQuery = _context.Set<Product>().Include(p => p.Brand).Include(p => p.Type).AsNoTracking()
                .Where(
                    x => (string.IsNullOrEmpty(brand_id.ToString())) || x.BrandId == brand_id
                ).Where(
                    x => (string.IsNullOrEmpty(type_id.ToString())) || x.TypeId == type_id
                ).Where(
                    x => (string.IsNullOrEmpty(priceStarts.ToString()) | string.IsNullOrEmpty(priceEnds.ToString())) ||
                    (x.Value >= priceStarts && x.Value <= priceEnds)
                );

                if (orderBy == "asc")
                {
                    productListQuery.OrderBy(x => x.Value);
                }
                else
                {
                    productListQuery.OrderByDescending(x => x.Value);
                }

                var productList = await productListQuery.ToListAsync();

                return productList;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.ToString());
            }
        }
    }
}