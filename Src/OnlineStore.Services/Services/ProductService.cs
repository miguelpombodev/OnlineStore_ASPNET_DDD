using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;
using OnlineStore.Services.Errors;

namespace OnlineStore.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetById(Guid id)
        {
            try
            {
                var product = await _repository.GetById(id);

                if (product == null)
                {
                    throw new ServiceError("Product not found", 404);
                }

                return product;
            }
            catch (ServiceError e)
            {
                throw e;
            }
            catch (DbUpdateException e)
            {
                throw new ServiceError("Internal Server Error", 500, e.ToString());
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
            var productList = await _repository.GetAllProducts(type_id, brand_id, priceStarts, priceEnds, orderBy);
            return productList;
        }
    }
}