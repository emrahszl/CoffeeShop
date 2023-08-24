using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public class ProductViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; } = null!;

        [Required]
        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Product Image")]
        [DataType(DataType.ImageUrl)]
        public IFormFile? ProductImage { get; set; }

        [Required]
        [Display(Name = "Product Stock")]
        public int ProductStock { get; set; }
    }
}
