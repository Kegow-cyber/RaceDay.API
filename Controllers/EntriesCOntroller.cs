using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EntriesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Entries.ToListAsync());

        [HttpGet("my")]
        public async Task<IActionResult> MyEntries()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return Unauthorized();
            var entries = await _context.Entries.Where(e => e.UserId == userId).ToListAsync();
            return Ok(entries);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entry entry)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId!= null) entry.UserId = userId.Value;
            entry.EntryDate = DateTime.UtcNow;

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();
            return Ok(entry);
        }
    }
}