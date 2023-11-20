namespace OnlineStore.Domain.Models
{
    public class CartItems
    {
        public CartItems(Guid id, Guid customerId, Guid cartId, Guid productId, int itemQuantity)
        {
            Id = id;
            CustomerId = customerId;
            CartId = cartId;
            ProductId = productId;
            ItemQuantity = itemQuantity;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int ItemQuantity { get; set; }
    }
}