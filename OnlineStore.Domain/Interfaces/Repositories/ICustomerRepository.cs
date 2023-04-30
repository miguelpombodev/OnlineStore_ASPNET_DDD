using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(Guid id);

    }
}