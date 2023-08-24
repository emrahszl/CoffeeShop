using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _db;

        public ProductController(ProductDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Store()
        {
            return View(_db.Products.ToList());
        }
    }
}
