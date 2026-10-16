using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDay.API.Data;
using RaceDay.API.Models;

namespace RaceDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EventsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Events.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event ev)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId!= null) ev.CreatedByUserId = userId.Value;

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return Ok(ev);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Event updated)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            ev.Name = updated.Name;
            ev.Location = updated.Location;
            ev.Date = updated.Date;
            await _context.SaveChangesAsync();
            return Ok(ev);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Deleted" });
        }
    }
}