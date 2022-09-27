using api_sistema.modells;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_clientesController : ControllerBase
    {
        private readonly dcontext dcontext;

        public t_clientesController(dcontext context)
        {
            this.dcontext = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_cliente>>> Gett_t_cliente()
        {
            if(dcontext.t_cliente == null)
            {
                return NotFound();
            }
            return await dcontext.t_cliente.Include("t_tipodocumento").ToListAsync();
        }
        [HttpGet("{documento}")]
        public async Task<ActionResult<t_cliente>> Gett_t_cliente(int documento)
        {
            if(dcontext.t_cliente == null)
            {
                return NotFound();
            }
            var t_cliente = await dcontext.t_cliente.
                Include("t_tipodocumento").FirstOrDefaultAsync(x => x.cli_doc == documento);
            if(t_cliente == null)
            {
                return NotFound();
            }
            return t_cliente;
        }
        [HttpPost]
        public async Task<ActionResult<t_cliente>> postt_cliente(t_cliente t_Cliente){
            
            if(dcontext.t_cliente == null)
            {
                return Problem("error");
            }
            dcontext.t_cliente.Add(t_Cliente);
            await dcontext.SaveChangesAsync();

            return CreatedAtAction("Gett_t_cliente", new { id = t_Cliente.cli_doc }, t_Cliente);
        }

        [HttpPut("{documento}")]
        public async Task<IActionResult> putt_cliente(int documento, t_cliente t_cliente)
        {
            if (documento != t_cliente.cli_doc)
            {
                return BadRequest();
            }
            dcontext.Entry(t_cliente).State = EntityState.Modified;

            try
            {
                await dcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_clienteexists(documento))
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

        private bool t_clienteexists(int documento)
        {
            return (dcontext.t_cliente?.Any(e => e.cli_doc == documento)).GetValueOrDefault();
        }

        [HttpDelete("{documento}")]
        public async Task<IActionResult> deletet_cliente(int documento)
        {
            if(dcontext.t_cliente == null)
            {
                return NotFound();
            }
            var t_cliente = await dcontext.t_cliente.FindAsync(documento);
            if(t_cliente == null)
            {
                return NotFound();
            }
            dcontext.t_cliente.Remove(t_cliente);
            await dcontext.SaveChangesAsync();

            return NotFound();
        }
    }
}
