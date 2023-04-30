using OnlineStore.Domain.Interfaces.Repositories;
using OnlineStore.Domain.Interfaces.Services;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Services
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
            var customer = await _repository.GetById(id);

            return customer;
        }
    }
}