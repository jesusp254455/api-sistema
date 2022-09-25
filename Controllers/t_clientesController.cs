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
    }
}
