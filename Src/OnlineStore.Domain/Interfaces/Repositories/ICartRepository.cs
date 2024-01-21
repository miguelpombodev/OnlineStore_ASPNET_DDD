using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartAsync(Guid userId);

        Task<Cart> CreateCartAsync(Guid userId);
    }
}