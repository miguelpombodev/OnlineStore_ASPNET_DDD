using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(Guid id);
    }
}