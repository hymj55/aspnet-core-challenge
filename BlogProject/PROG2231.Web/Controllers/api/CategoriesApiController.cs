using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG2231.Web.Data;
using PROG2231.Web.Models;

namespace PROG2231.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoriesApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _db.Categories.ToListAsync();
            return Ok(categories);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        // DELETE by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
