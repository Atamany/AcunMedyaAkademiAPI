using AcunMedyaAkademiWebAPI.Context;
using AcunMedyaAkademiWebAPI.DTOs.ProductDTO;
using AcunMedyaAkademiWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaAkademiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        public ProductsController(WebApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpGet("GetAllWithCategory")]
        public IActionResult GetAllWithCategory()
        {
            var products = _context.Products.Include(x=>x.Category).Select(p=>new ProductWithCategoryDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category.CategoryName
            }).ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var products = _context.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateDTO productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                CategoryId = productDto.CategoryId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created("", product);
        }
        [HttpPut]
        public IActionResult Update(ProductUpdateDTO productDto)
        {
            var product = _context.Products.Find(productDto.ProductId);
            if (product == null)
                return NotFound();
            product.ProductName = productDto.ProductName;
            product.Price = productDto.Price;
            product.ImageUrl = productDto.ImageUrl;
            product.CategoryId = productDto.CategoryId;
            _context.Products.Update(product);
            _context.SaveChanges();
            return StatusCode(204, new { message = "Ürün Güncellendi!" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
