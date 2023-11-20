using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Context;

namespace OnlineStore.Infra.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;

        public CartRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Cart> CreateCartAsync(Guid userId)
        {
            var newCart = new Cart(
                userId,
                false
            );

            await _context.AddAsync(newCart);
            await _context.SaveChangesAsync();

            return newCart;
        }

        public async Task<Cart>? GetCartAsync(Guid userId)
        {
            var cart = await _context.Set<Cart>().AsNoTracking().Where(x => x.CustomerId == userId).FirstOrDefaultAsync();

            return cart;
        }
    }
}