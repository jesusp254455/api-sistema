using api_sistema.modells;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_fact_detaController : ControllerBase
    {
        public readonly dcontext context;
        public t_fact_detaController (dcontext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_fact_deta>>> Gett_t_fact_deta()
        {
            if(context.t_fact_deta == null)
            {
                return NotFound();
            }
            
            return await context.t_fact_deta.Include("t_producto").ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<t_fact_deta>> Gett_t_fact_deta(int id)
        {
            if(context.t_fact_deta == null)
            {
                return NotFound();
            }
            var t_detalle = await context.t_fact_deta
                .Include("t_producto").FirstOrDefaultAsync(x => x.fd_id == id);
            if(t_detalle == null)
            {
                return NotFound();
            }
            return t_detalle;
        }

        [HttpPost]
        public async Task<ActionResult<t_fact_deta>> postt_cliente(t_fact_deta t_fact_deta)
        {

            if (context.t_fact_deta == null)
            {
                return Problem("error");
            }
            context.t_fact_deta.Add(t_fact_deta);
            await context.SaveChangesAsync();

            return CreatedAtAction("Gett_t_cliente", new { id = t_fact_deta.fd_id }, t_fact_deta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putt_cliente(int id, t_fact_deta t_fact_deta)
        {
            if (id != t_fact_deta.fd_id)
            {
                return BadRequest();
            }
            context.Entry(t_fact_deta).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_fact_detaexists(id))
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

        private bool t_fact_detaexists(int id)
        {
            return (context.t_fact_deta?.Any(e => e.fd_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletet_cliente(int id)
        {
            if (context.t_fact_deta == null)
            {
                return NotFound();
            }
            var t_fact_detas = await context.t_fact_deta.FindAsync(id);
            if (t_fact_detas == null)
            {
                return NotFound();
            }
            context.t_fact_deta.Remove(t_fact_detas);
            await context.SaveChangesAsync();

            return NotFound();
        }
    }
}
