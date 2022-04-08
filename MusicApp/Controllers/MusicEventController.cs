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
    public class MusicEventController : ControllerBase
    {
        private readonly MusicAppContext _context;

        public MusicEventController(MusicAppContext context)
        {
            _context = context;
        }

        // GET: api/MusicEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicEvent>>> GetMusEvent()
        {
            return await _context.MusEvent.ToListAsync();
        }

        // GET: api/MusicEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicEvent>> GetMusicEvent(long id)
        {
            var musicEvent = await _context.MusEvent.FindAsync(id);

            if (musicEvent == null)
            {
                return NotFound();
            }

            return musicEvent;
        }

        // PUT: api/MusicEvent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicEvent(long id, MusicEvent musicEvent)
        {
            if (id != musicEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicEventExists(id))
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

        // POST: api/MusicEvent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicEvent>> PostMusicEvent(MusicEvent musicEvent)
        {
            _context.MusEvent.Add(musicEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicEvent", new { id = musicEvent.Id }, musicEvent);
        }

        // DELETE: api/MusicEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicEvent(long id)
        {
            var musicEvent = await _context.MusEvent.FindAsync(id);
            if (musicEvent == null)
            {
                return NotFound();
            }

            _context.MusEvent.Remove(musicEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicEventExists(long id)
        {
            return _context.MusEvent.Any(e => e.Id == id);
        }
    }
}
