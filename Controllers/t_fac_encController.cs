using api_sistema.modells;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_fac_encController : ControllerBase
    {
        public readonly dcontext context;

        public t_fac_encController(dcontext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_fac_enc>>> Gett_t_fac_enc()
        {
            if(context.t_fac_enc == null)
            {
                return NotFound();
            }
            return await context.t_fac_enc.Include("t_cliente").Include("t_fact_deta").ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<t_fac_enc>> Gett_t_fac_enc(int id)
        {
            if(context.t_fac_enc == null)
            {
                return NotFound();
            }
            var t_encabezado = await context.t_fac_enc
                 .Include("t_fact_deta").FirstOrDefaultAsync(x => x.fe_id == id);
            if(t_encabezado == null)
            {
                return NotFound();
            }
            return t_encabezado;
        }
        [HttpPost]
        public async Task<ActionResult<t_fac_enc>> postt_cliente(t_fac_enc t_fac_enc)
        {

            if (context.t_fac_enc == null)
            {
                return Problem("error");
            }
            context.t_fac_enc.Add(t_fac_enc);
            await context.SaveChangesAsync();

            return CreatedAtAction("Gett_t_cliente", new { id = t_fac_enc.fe_id }, t_fac_enc);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> putt_cliente(int id, t_fac_enc t_fac_enc)
        {
            if (id != t_fac_enc.fe_id)
            {
                return BadRequest();
            }
            context.Entry(t_fac_enc).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_fac_encexist(id))
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

        private bool t_fac_encexist(int id)
        {
            return (context.t_fac_enc?.Any(e => e.fe_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletet_cliente(int id)
        {
            if (context.t_fac_enc == null)
            {
                return NotFound();
            }
            var t_fac_encs = await context.t_fac_enc.FindAsync(id);
            if (t_fac_encs == null)
            {
                return NotFound();
            }
            context.t_fac_enc.Remove(t_fac_encs);
            await context.SaveChangesAsync();

            return NotFound();
        }
    }
}
