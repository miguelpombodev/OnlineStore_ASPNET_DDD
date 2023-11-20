using OnlineStore.Domain.DTO;
using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;
using OnlineStore.Services.Errors;

namespace OnlineStore.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        async public Task<Customer> GetById(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);

            return customer;
        }


        async public Task<Customer> GetByEmail(string email)
        {
            var customer = await _repository.GetByEmailAsync(email);

            if (customer is null)
            {
                throw new ServiceError("User is not registered!", 404);
            }

            return customer;
        }

        async public Task<Customer> SaveCustomer(CreateCustomerDTO customer)
        {
            var getUserByEmail = await _repository.GetByEmailAsync(customer.Email);

            if (getUserByEmail != null)
            {
                throw new Exception("User already registered!");
            }

            var createdCustomer = await _repository.SaveAsync(customer);

            return createdCustomer;
        }
    }
}