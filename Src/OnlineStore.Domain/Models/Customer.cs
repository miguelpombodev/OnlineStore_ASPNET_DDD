using OnlineStore.Domain.ValueObjects;

namespace OnlineStore.Domain.Models
{
    public class Customer : BaseEntity
    {
        public Customer(string name, string surname, string cPF, string email, string password, DateTime createdAt, DateTime updatedAt)
        {
            Name = name;
            Surname = surname;
            CPF = cPF;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}