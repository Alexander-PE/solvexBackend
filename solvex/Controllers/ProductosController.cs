using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex.DTOs;
using solvex.Entidades;

namespace solvex.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProductosController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductosCreacionDTO productoCreacion)
        {
            var producto = mapper.Map<Producto>(productoCreacion);

            context.Add(producto);
            await context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Producto>> Delete(int id)
        {
            var producto = await context.Productos.SingleOrDefaultAsync(x => x.Id == id);
            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Producto>>> Get(int id)
        {
            List<Producto> productoss = new List<Producto>();
            var producto = await context.Productos.SingleOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            productoss.Add(producto);
            return productoss;
        }




    }
}
