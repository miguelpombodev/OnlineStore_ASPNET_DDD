using OnlineStore.Domain.DTO.Customers;
using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Customer> Login(CustomerLoginDTO customer);
    }
}