namespace OnlineStore.Domain.Interfaces.Services
{
    public interface IHttpClientService
    {
        Task<object> GetAsync(string uri);
    }
}