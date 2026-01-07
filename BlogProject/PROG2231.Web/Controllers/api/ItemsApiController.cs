using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG2231.Web.Data;
using PROG2231.Web.Models;

namespace PROG2231.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    // Hiding from Swagger. Cannot delete controller because it is still referenced elsewhere, which would break the build.
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ItemsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ItemsApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _db.Items.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _db.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            _db.Items.Remove(item);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
