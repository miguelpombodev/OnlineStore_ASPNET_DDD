namespace OnlineStore.Domain.Models
{
    public class Product : BaseEntity
    {
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int StockAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ProductBrand Brand { get; set; }
        public virtual ProductType Type { get; set; }
    }
}