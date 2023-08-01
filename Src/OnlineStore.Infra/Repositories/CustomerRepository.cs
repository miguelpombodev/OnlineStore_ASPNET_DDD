using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.DTO;
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

        async public Task<Customer> GetByEmail(string email)
        {
            try
            {
                var user = await _context.Set<Customer>().AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

                return user;
            }
            catch (DbUpdateException e)
            {

                throw new DbUpdateException(e.ToString());
            }
        }

        async public Task<Customer> Save(CreateCustomerDTO customer)
        {
            try
            {
                var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(customer.Password);

                var createUser = new Customer(
                    customer.Name,
                    customer.Surname,
                    customer.CPF,
                    customer.Email,
                    customer.Password = encryptedPassword,
                    customer.Cellphone,
                    customer.Sex,
                    customer.BirthDate,
                    DateTime.Now,
                    DateTime.Now
                );

                await _context.AddAsync(createUser);
                await _context.SaveChangesAsync();

                return createUser;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.ToString());
            }
        }
    }
}