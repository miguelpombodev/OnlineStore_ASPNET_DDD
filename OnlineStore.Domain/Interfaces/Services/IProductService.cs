using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> GetById(Guid id);
    }
}