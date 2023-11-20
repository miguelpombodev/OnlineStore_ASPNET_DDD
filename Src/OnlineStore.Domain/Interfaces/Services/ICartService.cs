using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface ICartService
    {
        Task<Cart>? GetCartOrCreateAsync(Guid userId);

        Task<string> CreateCartAsync(Guid userId);

        Task<string> AddCartItemsAsync(Guid userId, Guid cartId, Guid productId, int itemQuantity);

        Task<string> DeleteCartItemsAsync(Guid userId, Guid cartId, Guid productId, int itemQuantity);

        Task<string> UpdateCartItemsAsync(Guid userId, Guid cartId, Guid productId, int itemQuantity);

    }
}