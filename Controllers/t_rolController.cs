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
    public class t_rolController : ControllerBase
    {
        private readonly dcontext _context;

        public t_rolController(dcontext context)
        {
            _context = context;
        }

        // GET: api/t_rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_rol>>> Gett_rol()
        {
          if (_context.t_rol == null)
          {
              return NotFound();
          }
            return await _context.t_rol.ToListAsync();
        }

        // GET: api/t_rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<t_rol>> Gett_rol(int id)
        {
          if (_context.t_rol == null)
          {
              return NotFound();
          }
            var t_rol = await _context.t_rol.FindAsync(id);

            if (t_rol == null)
            {
                return NotFound();
            }

            return t_rol;
        }

        // PUT: api/t_rol/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putt_rol(int id, t_rol t_rol)
        {
            if (id != t_rol.rolId)
            {
                return BadRequest();
            }

            _context.Entry(t_rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_rolExists(id))
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

        // POST: api/t_rol
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<t_rol>> Postt_rol(t_rol t_rol)
        {
          if (_context.t_rol == null)
          {
              return Problem("Entity set 'dcontext.t_rol'  is null.");
          }
            _context.t_rol.Add(t_rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gett_rol", new { id = t_rol.rolId }, t_rol);
        }

        // DELETE: api/t_rol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet_rol(int id)
        {
            if (_context.t_rol == null)
            {
                return NotFound();
            }
            var t_rol = await _context.t_rol.FindAsync(id);
            if (t_rol == null)
            {
                return NotFound();
            }

            _context.t_rol.Remove(t_rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool t_rolExists(int id)
        {
            return (_context.t_rol?.Any(e => e.rolId == id)).GetValueOrDefault();
        }
    }
}
