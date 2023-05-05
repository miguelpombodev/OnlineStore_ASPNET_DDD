using OnlineStore.Domain.DTO;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByEmail(string email);

        Task<Customer> Save(CreateCustomerDTO customer);

    }
}