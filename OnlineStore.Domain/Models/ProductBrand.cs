namespace OnlineStore.Domain.Models
{
    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}