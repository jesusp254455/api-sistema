using api_sistema.modells;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_productosController : ControllerBase
    {
        private readonly dcontext dcontext;

        public t_productosController(dcontext context)
        {
            dcontext = context;
        }
      [HttpGet]
       public async Task<ActionResult<IEnumerable<t_producto>>> Gett_t_producto()
        {
            if (dcontext.t_producto == null)
            {
                return NotFound();
            }
            return await dcontext.t_producto.Include("t_categoria").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<t_producto>> Gett_t_producto(int id)
        {
            if(dcontext.t_producto == null)
            {
                return NotFound();
            }
            var t_producto = await dcontext.t_producto.
                Include("t_categoria").FirstOrDefaultAsync(x =>x.pro_id == id);
            if(t_producto == null)
            {
                return NotFound();
            }
            return t_producto;
        }
    }
}
