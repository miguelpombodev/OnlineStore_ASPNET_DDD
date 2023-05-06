using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
        Task<List<Product>> GetAllProducts(
            int? type_id,
            int? brand_id,
            decimal? priceStarts,
            decimal? priceEnds,
            string? orderBy
        );
    }
}