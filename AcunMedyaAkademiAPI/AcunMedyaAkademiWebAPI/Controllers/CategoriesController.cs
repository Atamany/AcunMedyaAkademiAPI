using AcunMedyaAkademiWebAPI.Context;
using AcunMedyaAkademiWebAPI.DTOs.CategoriesDTO;
using AcunMedyaAkademiWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaAkademiWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        public CategoriesController(WebApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categories = _context.Categories.Find(id);
            if(categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult Create(CategoriesCreateDTO categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Created("", category);
        }
    }
}
