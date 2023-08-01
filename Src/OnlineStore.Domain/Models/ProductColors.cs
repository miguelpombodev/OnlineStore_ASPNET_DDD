namespace OnlineStore.Domain.Models
{
    public class ProductColors : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ProductColorURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product Product;
    }
}