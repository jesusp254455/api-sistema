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
            if(context.t_fac_encs == null)
            {
                return NotFound();
            }
            return await context.t_fac_encs.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<t_fac_enc>> Gett_t_fac_enc(int id)
        {
            if(context.t_fac_encs == null)
            {
                return NotFound();
            }
            var t_encabezado = await context.t_fac_encs
                 .Include("t_cliente").FirstOrDefaultAsync(x => x.fe_id == id);
            if(t_encabezado == null)
            {
                return NotFound();
            }
            return t_encabezado;
        }
    }
}
