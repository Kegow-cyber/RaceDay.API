using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll(int? eventId)
        {
            var query = _context.Categories.AsQueryable();
            if (eventId!= null) query = query.Where(c => c.EventId == eventId);
            return Ok(await query.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category cat)
        {
            _context.Categories.Add(cat);
            await _context.SaveChangesAsync();
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat == null) return NotFound();
            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Deleted" });
        }
    }
}