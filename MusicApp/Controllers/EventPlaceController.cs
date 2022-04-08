#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Domain.Models;
using MusicApp.Infrastructure.Database;

namespace MusicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPlaceController : ControllerBase
    {
        private readonly MusicAppContext _context;

        public EventPlaceController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: api/EventPlace
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventPlace>>> GetEventPlace()
        {
            return await _context.EventPlace.ToListAsync();
        }

        // GET: api/EventPlace/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventPlace>> GetEventPlace(string id)
        {
            var eventPlace = await _context.EventPlace.FindAsync(id);

            if (eventPlace == null)
            {
                return NotFound();
            }

            return eventPlace;
        }

        // PUT: api/EventPlace/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventPlace(string id, EventPlace eventPlace)
        {
            if (id != eventPlace.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventPlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventPlace
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventPlace>> PostEventPlace(EventPlace eventPlace)
        {
            _context.EventPlace.Add(eventPlace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventPlaceExists(eventPlace.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEventPlace", new { id = eventPlace.Id }, eventPlace);
        }

        // DELETE: api/EventPlace/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventPlace(string id)
        {
            var eventPlace = await _context.EventPlace.FindAsync(id);
            if (eventPlace == null)
            {
                return NotFound();
            }

            _context.EventPlace.Remove(eventPlace);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventPlaceExists(string id)
        {
            return _context.EventPlace.Any(e => e.Id == id);
        }
    }
}
