using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjAula30082021.Data;
using ProjAula30082021.Models;

namespace ProjAula30082021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadariasController : ControllerBase
    {
        private readonly ProjAula30082021Context _context;

        public PadariasController(ProjAula30082021Context context)
        {
            _context = context;
        }

        // GET: api/Padarias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Padarias>>> GetPadarias()
        {
            return await _context.Padarias.ToListAsync();
        }

        // GET: api/Padarias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Padarias>> GetPadarias(int id)
        {
            var padarias = await _context.Padarias.FindAsync(id);

            if (padarias == null)
            {
                return NotFound();
            }

            return padarias;
        }

        // PUT: api/Padarias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPadarias(int id, Padarias padarias)
        {
            if (id != padarias.Id)
            {
                return BadRequest();
            }

            _context.Entry(padarias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadariasExists(id))
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

        // POST: api/Padarias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Padarias>> PostPadarias(Padarias padarias)
        {
            _context.Padarias.Add(padarias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPadarias", new { id = padarias.Id }, padarias);
        }

        // DELETE: api/Padarias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePadarias(int id)
        {
            var padarias = await _context.Padarias.FindAsync(id);
            if (padarias == null)
            {
                return NotFound();
            }

            _context.Padarias.Remove(padarias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PadariasExists(int id)
        {
            return _context.Padarias.Any(e => e.Id == id);
        }
    }
}
