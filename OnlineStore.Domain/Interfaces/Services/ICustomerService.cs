using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetById(Guid id);

    }
}