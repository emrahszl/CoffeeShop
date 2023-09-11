using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeShopAPI.Data.Context;
using CoffeeShopAPI.Data.Entities;
using CoffeeShopAPI.Dtos;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly Product _product;

        public ProductsController(ApplicationDbContext db, Product product)
        {
            _db = db;
            _product = product;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_db.Products == null)
            {
                return NotFound();
            }
            return await _db.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_db.Products == null)
            {
                return NotFound();
            }
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, PutProductDto putProductDto)
        {
            var product = _db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = putProductDto.ProductName;
            product.ProductPrice = putProductDto.ProductPrice;
            product.ProductStock = putProductDto.ProductStock;

            if (putProductDto.ProductImage != null)
            {
                var fileName = putProductDto.ProductImage.FileName;
                _product.ProductImageName = fileName;
                var route = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                var flowArea = new FileStream(route, FileMode.Create);
                putProductDto.ProductImage.CopyTo(flowArea);
                flowArea.Close();
            }

            await _db.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostProductDto>> PostProduct(PostProductDto postProductDto)
        {
            if (_db.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }

            _product.ProductName = postProductDto.ProductName;
            _product.ProductPrice = postProductDto.ProductPrice;
            _product.ProductStock = postProductDto.ProductStock;

            if (postProductDto.ProductImage != null)
            {
                var fileName = postProductDto.ProductImage.FileName;
                _product.ProductImageName = fileName;
                var route = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
                var flowArea = new FileStream(route, FileMode.Create);
                postProductDto.ProductImage.CopyTo(flowArea);
                flowArea.Close();
            }

            _db.Products.Add(_product);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = _product.Id }, _product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_db.Products == null)
            {
                return NotFound();
            }
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
