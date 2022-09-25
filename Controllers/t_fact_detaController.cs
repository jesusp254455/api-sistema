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
            if(context.t_fact_detas == null)
            {
                return NotFound();
            }
            
            return await context.t_fact_detas.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<t_fact_deta>> Gett_t_fact_deta(int id)
        {
            if(context.t_fact_detas == null)
            {
                return NotFound();
            }
            var t_detalle = await context.t_fact_detas
                .Include("t_producto").FirstOrDefaultAsync(x => x.fd_id == id);
            if(t_detalle == null)
            {
                return NotFound();
            }
            return t_detalle;
        }
    }
}
