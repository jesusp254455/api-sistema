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
    public class t_usuarioController : ControllerBase
    {
        private readonly dcontext _context;

        public t_usuarioController(dcontext context)
        {
            _context = context;
        }

        // GET: api/t_usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_usuario>>> Gett_usuario()
        {
          if (_context.t_usuario == null)
          {
              return NotFound();
          }
            return await _context.t_usuario.Include("t_rol")
                .Include("t_tipodocumento")
                .ToListAsync();
        }

        // GET: api/t_usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<t_usuario>> Gett_usuario(int id)
        {
          if (_context.t_usuario == null)
          {
              return NotFound();
          }
            var t_usuario = await _context.t_usuario.FindAsync(id);

            if (t_usuario == null)
            {
                return NotFound();
            }

            return t_usuario;
        }

        // PUT: api/t_usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putt_usuario(int id, t_usuario t_usuario)
        {
            if (id != t_usuario.id)
            {
                return BadRequest();
            }

            _context.Entry(t_usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_usuarioExists(id))
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

        // POST: api/t_usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<t_usuario>> Postt_usuario(t_usuario t_usuario)
        {
          if (_context.t_usuario == null)
          {
              return Problem("Entity set 'dcontext.t_usuario'  is null.");
          }
            _context.t_usuario.Add(t_usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gett_usuario", new { id = t_usuario.id }, t_usuario);
        }

        // DELETE: api/t_usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletet_usuario(int id)
        {
            if (_context.t_usuario == null)
            {
                return NotFound();
            }
            var t_usuario = await _context.t_usuario.FindAsync(id);
            if (t_usuario == null)
            {
                return NotFound();
            }

            _context.t_usuario.Remove(t_usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool t_usuarioExists(int id)
        {
            return (_context.t_usuario?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
