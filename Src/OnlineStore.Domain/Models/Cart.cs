namespace OnlineStore.Domain.Models
{
    public class Cart : BaseEntity
    {
        public Cart(Guid customerId, bool purchased)
        {
            CustomerId = customerId;
            Purchased = purchased;
        }

        public Guid CustomerId { get; set; }
        public bool Purchased { get; set; }

    }
}