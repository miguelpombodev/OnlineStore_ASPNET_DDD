using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;

namespace OnlineStore.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public Task<string> AddCartItemsAsync(Guid userId, Guid cartId, Guid productId, int itemQuantity)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteCartItemsAsync(Guid userId, Guid cartId, Guid productId, int itemQuantity)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartOrCreateAsync(Guid userId)
        {
            var cart = await _repository.GetCartAsync(userId);

            if (cart is null)
            {
                cart = await _repository.CreateCartAsync(userId);
            }

            return cart;
        }

        public Task<string> UpdateCartItemsAsync(Guid userId, Guid cartId, Guid productId, int itemQuantity)
        {
            throw new NotImplementedException();
        }
    }
}