using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface IProductService
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