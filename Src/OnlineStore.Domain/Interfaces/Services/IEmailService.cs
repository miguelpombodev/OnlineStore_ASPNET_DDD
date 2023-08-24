namespace OnlineStore.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        bool SendEmail(string from, string to, string title, string message);
    }
}