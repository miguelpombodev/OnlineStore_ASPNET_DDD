namespace OnlineStore.Domain.Models
{
    public class Product : BaseEntity
    {
        public Product(int typeId, int brandId, string sku, string name, decimal value, int stockAmount, DateTime createdAt, DateTime updatedAt)
        {
            TypeId = typeId;
            BrandId = brandId;
            Sku = sku;
            Name = name;
            Value = value;
            StockAmount = stockAmount;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int TypeId { get; private set; }
        public int BrandId { get; private set; }
        public string Sku { get; private set; }
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public int StockAmount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public virtual ProductBrand Brand { get; set; }
        public virtual ProductType Type { get; set; }
        public IList<ProductColors> Colors { get; set; }
    }
}