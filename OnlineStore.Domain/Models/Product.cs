using System;

namespace OnlineStore.Domain.Models
{
    public class Product
    {
        public Guid id;
        public int type_id;
        public int brand_id;
        public string sku;
        public string name;
        public decimal value;
        public int stock_amount;
        public DateTime created_at;
        public DateTime updated_at;
    }
}