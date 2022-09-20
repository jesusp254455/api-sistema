using api_sistema.modells;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class t_categoriasController : ControllerBase
    {
        private readonly dcontext dcontext;
        public t_categoriasController(dcontext context)
        {
            dcontext = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<t_categoria>>> Gett_t_categoria()
        {
            if(dcontext.t_categoria == null)
            {
                return NotFound();
            }
            return await dcontext.t_categoria.ToListAsync();
        }
        [HttpGet("{cat_id}")]
        public async Task<ActionResult<t_categoria>> Gett_t_categoria(int cat_id)
        {
            if(dcontext.t_categoria == null)
            {
                return NotFound();
            }
            var t_categoria = await dcontext.t_categoria.FindAsync(cat_id);
            if (t_categoria == null)
            {
                return NotFound();
            }
            return t_categoria;
        }

    }
}
