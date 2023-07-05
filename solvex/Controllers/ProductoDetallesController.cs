using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex.DTOs;
using solvex.Entidades;

namespace solvex.Controllers
{
    [ApiController]
    [Route("api/detalle")]
    public class ProductoDetallesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProductoDetallesController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDetalle>>> Get()
        {
            return await context.ProductoDetalles.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProductoDetalle>>> Get(int id)
        {
            var detalle = await context.ProductoDetalles.ToListAsync();
            if (detalle == null)
            {
                return NotFound();
            }

            var detalleFinal = detalle.FindAll(x => x.ProductoId == id).ToList();
            return detalleFinal;
        }


        [HttpGet("user/{usuarioId:int}")]
        public async Task<ActionResult<IEnumerable<ProductoDetalle>>> GetAllByUser(int usuarioId)
        {
            var detalle = await context.ProductoDetalles.ToListAsync();
            if (detalle == null)
            {
                return NotFound();
            }

            var detalleFinal = detalle.FindAll(x => x.UsuarioId == usuarioId).ToList();
            return detalleFinal;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductoDetalle>> Delete(int id)
        {
            var detalle = await context.ProductoDetalles.SingleOrDefaultAsync(x => x.Id == id);
            context.ProductoDetalles.Remove(detalle);
            await context.SaveChangesAsync();
            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductoDetallesCreacionDTO detalleCreacion)
        {
            var detalle = mapper.Map<ProductoDetalle>(detalleCreacion);
            context.Add(detalle);
            await context.SaveChangesAsync();
            return Ok(detalle);
        }


    }
}
