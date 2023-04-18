namespace OnlineStore.Domain.ValueObjects
{
    public class Email
    {
        public Email(string email)
        {
            this.email = email;
        }

        public string email { get; set; }
    }
}