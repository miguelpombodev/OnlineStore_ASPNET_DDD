using OnlineStore.Domain.Models;

namespace OnlineStore.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(Customer customer);
        string DecodeToken(string token);
    }
}