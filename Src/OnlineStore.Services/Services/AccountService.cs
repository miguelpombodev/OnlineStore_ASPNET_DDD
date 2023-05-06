using OnlineStore.Domain.DTO.Customers;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;

namespace OnlineStore.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly ICustomerRepository _repository;
        public AccountService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Login(CustomerLoginDTO customer)
        {
            try
            {
                var registeredCustomer = await _repository.GetByEmail(customer.Email);

                var validatedUserPassword = BCrypt.Net.BCrypt.Verify(customer.Password, registeredCustomer.Password);

                if (validatedUserPassword == false)
                {
                    throw new Exception("Password incorrect");
                }

                return registeredCustomer;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}