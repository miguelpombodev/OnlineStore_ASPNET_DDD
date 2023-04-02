namespace OnlineStore.Domain.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public IList<Product> Products;
    }
}