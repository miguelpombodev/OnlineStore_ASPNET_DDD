using OnlineStore.Domain.DTO;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByEmail(string email);
        Task<Customer> SaveCustomer(CreateCustomerDTO customer);

    }
}