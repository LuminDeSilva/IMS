using IMS.Data;
using IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMSContext _context;

        public ProductController(IMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }

            // Ensure the ProductId is not set to prevent identity column errors
            product.ProductId = 0;

            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProducts), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.QuantityInStock = updatedProduct.QuantityInStock;
            product.Price = updatedProduct.Price;
            product.MinimumStockLevel = updatedProduct.MinimumStockLevel;

            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("low-stock")]
        public IActionResult GetLowStockProducts()
        {
            var lowStockProducts = _context.Products
                .Where(p => p.QuantityInStock < p.MinimumStockLevel)
                .ToList();
            return Ok(lowStockProducts);
        }

        [HttpGet("out-of-stock")]
        public IActionResult GetOutOfStockProducts()
        {
            var outOfStockProducts = _context.Products
                .Where(p => p.QuantityInStock == 0)
                .ToList();
            return Ok(outOfStockProducts);
        }

        [HttpGet("inventory-report")]
        public IActionResult GetInventoryReport()
        {
            var totalProducts = _context.Products.Sum(p => p.QuantityInStock);
            var totalValue = _context.Products.Sum(p => p.QuantityInStock * p.Price);

            var report = new
            {
                TotalProductsInStock = totalProducts,
                TotalInventoryValue = totalValue
            };

            return Ok(report);
        }


    }
}
