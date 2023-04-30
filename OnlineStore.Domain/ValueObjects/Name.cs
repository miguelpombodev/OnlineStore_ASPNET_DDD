namespace OnlineStore.Domain.ValueObjects
{
    public class Name
    {
        public Name(string name, string surname)
        {
            this.FullName = name + surname;

        }
        public string FullName { get; set; }
    }
}