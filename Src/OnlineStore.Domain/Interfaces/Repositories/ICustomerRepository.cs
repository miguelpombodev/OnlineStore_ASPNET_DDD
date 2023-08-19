using OnlineStore.Domain.DTO;
using OnlineStore.Domain.DTO.Account;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> GetByEmailAsync(string email);

        Task<Customer> SaveAsync(CreateCustomerDTO customer);
        Task<Customer> UpdateAsync(Customer customer);

    }
}