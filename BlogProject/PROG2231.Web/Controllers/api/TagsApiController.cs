using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG2231.Web.Data;
using PROG2231.Web.Models;

namespace PROG2231.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TagsApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _db.Tags.ToListAsync();
            return Ok(tags);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tag = await _db.Tags.FindAsync(id);
            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            _db.Tags.Add(tag);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = tag.Id }, tag);
        }

        // DELETE by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tag = await _db.Tags.FindAsync(id);
            if (tag == null)
                return NotFound();

            _db.Tags.Remove(tag);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
