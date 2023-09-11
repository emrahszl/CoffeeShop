namespace CoffeeShopAPI.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public string? ProductImageName { get; set; }

        public int ProductStock { get; set; }
    }
}
