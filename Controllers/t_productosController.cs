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

        [HttpPost]
        public async Task<ActionResult<t_producto>> Postt_producto(t_producto t_Producto)
        {
            if(dcontext.t_producto == null)
            {
                return Problem("hay problemas de insercion");
            }
            dcontext.t_producto.Add(t_Producto);
            await dcontext.SaveChangesAsync();

            return CreatedAtAction("Gett_t_producto", new { id = t_Producto.pro_id }, t_Producto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> putt_producto(int id, t_producto t_producto)
        {
            if(id != t_producto.pro_id)
            {
                return BadRequest();
            }
            dcontext.   Entry(t_producto).State = EntityState.Modified;

            try
            {
                await dcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_productoExists(id))
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

        private bool t_productoExists(int id)
        {
            return (dcontext.t_producto?.Any(e => e.pro_id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletet_producto(int id)
        {
            if(dcontext.t_producto == null)
            {
                return NotFound();
            }
            var t_producto = await dcontext.t_producto.FindAsync(id);
            if(t_producto == null)
            {
                return NotFound();
            }
            dcontext.t_producto.Remove(t_producto);
            await dcontext.SaveChangesAsync();

            return NoContent();
        }
    }
}
