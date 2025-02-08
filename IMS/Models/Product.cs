namespace IMS.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public int MinimumStockLevel { get; set; }

        public string StockStatus
        {
            get
            {
                return QuantityInStock < MinimumStockLevel ? "Low Stock" : "In Stock";
            }
        }
    }
}
