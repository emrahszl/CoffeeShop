using CoffeeShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult Store()
        {
            return View();
        }
    }
}
