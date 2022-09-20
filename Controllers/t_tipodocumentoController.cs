using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_sistema;
using api_sistema.modells;

namespace api_sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_tipodocumentoController : ControllerBase
    {
        private readonly dcontext _context;

        public t_tipodocumentoController(dcontext context)
        {
            _context = context;
        }

        // GET: api/t_tipodocumento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_tipodocumento>>> Gett_tipodocumento()
        {
          if (_context.t_tipodocumento == null)
          {
              return NotFound();
          }
            return await _context.t_tipodocumento.ToListAsync();
        }

        // GET: api/t_tipodocumento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<t_tipodocumento>> Gett_tipodocumento(int id)
        {
          if (_context.t_tipodocumento == null)
          {
              return NotFound();
          }
            var t_tipodocumento = await _context.t_tipodocumento.FindAsync(id);

            if (t_tipodocumento == null)
            {
                return NotFound();
            }

            return t_tipodocumento;
        }

        // PUT: api/t_tipodocumento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putt_tipodocumento(int id, t_tipodocumento t_tipodocumento)
        {
            if (id != t_tipodocumento.tipodocumentoid)
            {
                return BadRequest();
            }

            _context.Entry(t_tipodocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_tipodocumentoExists(id))
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

        // POST: api/t_tipodocumento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<t_tipodocumento>> Postt_tipodocumento(t_tipodocumento t_tipodocumento)
        {
          if (_context.t_tipodocumento == null)
          {
              return Problem("Entity set 'dcontext.t_tipodocumento'  is null.");
          }
            _context.t_tipodocumento.Add(t_tipodocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gett_tipodocumento", new { id = t_tipodocumento.tipodocumentoid }, t_tipodocumento);
        }

        // DELETE: api/t_tipodocumento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet_tipodocumento(int id)
        {
            if (_context.t_tipodocumento == null)
            {
                return NotFound();
            }
            var t_tipodocumento = await _context.t_tipodocumento.FindAsync(id);
            if (t_tipodocumento == null)
            {
                return NotFound();
            }

            _context.t_tipodocumento.Remove(t_tipodocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool t_tipodocumentoExists(int id)
        {
            return (_context.t_tipodocumento?.Any(e => e.tipodocumentoid == id)).GetValueOrDefault();
        }
    }
}
