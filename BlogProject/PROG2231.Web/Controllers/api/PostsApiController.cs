using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG2231.Web.Data;
using PROG2231.Web.Models;

namespace PROG2231.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PostsApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _db.Posts
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .ToListAsync();
            return Ok(posts);
        }

        // GET by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _db.Posts
                .Include(p => p.Category)
                .Include(p => p.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null) return NotFound();
            return Ok(post);
        }

        // POST 
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        // DELETE by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            if (post == null) return NotFound();

            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
