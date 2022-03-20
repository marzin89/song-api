#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongAPI.Data;
using SongAPI.Models;

namespace SongAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly SongContext _context;

        public SongController(SongContext context)
        {
            _context = context;
        }

        // Hämtar alla låtar
        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongS()
        {
            return await _context.SongS.ToListAsync();
        }

        // Hämtar en specifik låt
        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            // Hämtar låten ur databasen
            var song = await _context.SongS.FindAsync(id);

            // Returnerar ett felmeddelande om låten inte finns
            if (song == null)
            {
                return NotFound();
            }

            // Returnerar låten
            return song;
        }

        // Uppdaterar en låt
        // PUT: api/Song/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            // Returnerar ett felmeddelande om id inte matchar
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            // Uppdaterar låten
            try
            {
                await _context.SaveChangesAsync();
            }
            // Returnerar ett felmeddelande om låten inte finns
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Returnerar ett tomt objekt
            return NoContent();
        }

        // Lägger till en låt
        // POST: api/Song
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            // Lägger till låten i databasen
            _context.SongS.Add(song);
            await _context.SaveChangesAsync();

            // Returnerar låten
            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // Raderar en låt
        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            // Hämtar låten ur databasen
            var song = await _context.SongS.FindAsync(id);

            // Returnerar ett felmeddelande om låten inte finns
            if (song == null)
            {
                return NotFound();
            }

            // Tar bort låten ur databasen
            _context.SongS.Remove(song);
            await _context.SaveChangesAsync();

            // Returnerar ett tomt objekt
            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.SongS.Any(e => e.Id == id);
        }
    }
}
