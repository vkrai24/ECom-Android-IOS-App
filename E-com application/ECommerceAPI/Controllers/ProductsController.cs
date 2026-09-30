using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Data;
using ECommerceAPI.DTOs;
using ECommerceAPI.Models;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    OriginalPrice = p.OriginalPrice,
                    Category = p.Category,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    Rating = p.Rating,
                    ReviewCount = p.ReviewCount
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                Stock = product.Stock,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount
            };

            return Ok(productDto);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(string category)
        {
            var products = await _context.Products
                .Where(p => p.Category == category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    OriginalPrice = p.OriginalPrice,
                    Category = p.Category,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    Rating = p.Rating,
                    ReviewCount = p.ReviewCount
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProducts([FromQuery] string q)
        {
            var products = await _context.Products
                .Where(p => p.Name.Contains(q) || (p.Description != null && p.Description.Contains(q)))
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    OriginalPrice = p.OriginalPrice,
                    Category = p.Category,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    Rating = p.Rating,
                    ReviewCount = p.ReviewCount
                })
                .ToListAsync();

            return Ok(products);
        }
    }
}
