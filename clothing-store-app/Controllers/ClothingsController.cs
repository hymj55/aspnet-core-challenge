using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Midterm_9031031.Data;
using Midterm_9031031.Models;

namespace Midterm_9031031.Controllers
{
    //This controller was created using scaffolding
    public class ClothingsController : Controller
    {
        private readonly ApplicationDbContext _context; // DB context to access Clothings table

        public ClothingsController(ApplicationDbContext context)
        {
            _context = context; // Using Dependency Injection
        }

        // GET: Clothings
        // Show the list of all clothing items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clothings.ToListAsync());
        }

        // GET: Clothings/Details/5
        // Show details of a single clothing item
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothings
                .FirstOrDefaultAsync(m => m.ClothingId == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // GET: Clothings/Create
        // Show the form to create a new clothing item
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clothings/Create
        // Handle form submission and add new clothing item to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClothingId,Name,Brand,Price,Size")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothing);
        }

        // GET: Clothings/Edit/5
        // Show the form to edit an existing clothing item
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothings.FindAsync(id);
            if (clothing == null)
            {
                return NotFound();
            }
            return View(clothing);
        }

        // POST: Clothings/Edit/5
        // Handle form submission to update an existing clothing item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClothingId,Name,Brand,Price,Size")] Clothing clothing)
        {
            if (id != clothing.ClothingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingExists(clothing.ClothingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clothing);
        }

        // GET: Clothings/Delete/5
        // Show confirmation page before deleting a clothing item
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothing = await _context.Clothings
                .FirstOrDefaultAsync(m => m.ClothingId == id);
            if (clothing == null)
            {
                return NotFound();
            }

            return View(clothing);
        }

        // POST: Clothings/Delete/5
        // Delete the clothing item from the DB
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothing = await _context.Clothings.FindAsync(id);
            if (clothing != null)
            {
                _context.Clothings.Remove(clothing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingExists(int id)
        {
            return _context.Clothings.Any(e => e.ClothingId == id);
        }
    }
}
