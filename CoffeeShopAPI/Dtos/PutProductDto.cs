namespace CoffeeShopAPI.Dtos
{
    public class PutProductDto
    {

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public IFormFile? ProductImage { get; set; }

        public int ProductStock { get; set; }
    }
}
