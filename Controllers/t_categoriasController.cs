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

        [HttpPost]
        public async Task<ActionResult<t_categoria>> postt_categoria(t_categoria t_categoria)
        {
            if(dcontext.t_categoria == null)
            {
                return Problem(" hay problemas de insercion");
            }
            dcontext.t_categoria.Add(t_categoria);
            await dcontext.SaveChangesAsync();

            return CreatedAtAction("get_t_categoria", new { id = t_categoria.cat_id }, t_categoria);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putt_categoria(int id, t_categoria t_categoria)
        {
            if(id != t_categoria.cat_id)
            {
                return BadRequest();
            }
            dcontext.Entry(t_categoria).State = EntityState.Modified;

            try
            {
                await dcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_categoriaexists(id))
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

        private bool t_categoriaexists(int id)
        {
            return (dcontext.t_categoria?.Any(e => e.cat_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletet_categoria(int id)
        {
            if(dcontext.t_categoria == null)
            {
                return NotFound();
            }
            var t_categoria = await dcontext.t_categoria.FindAsync(id);
            if (t_categoria == null)
            {
                return NotFound();
            }
            dcontext.t_categoria.Remove(t_categoria);
            await dcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
