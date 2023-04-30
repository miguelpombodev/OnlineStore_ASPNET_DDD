using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Models;
using OnlineStore.Infra.Context;

namespace OnlineStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        async public Task<Customer> GetById(Guid id)
        {
            var user = await _context.Set<Customer>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}