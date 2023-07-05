using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex.DTOs;
using solvex.Entidades;

namespace solvex.Controllers
{
    [ApiController]
    [Route("api/colores")]
    public class ColoresController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ColoresController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> Get()
        {
            return await context.Colores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ColoresCreacionDTO coloresCreacion)
        {
            var color = mapper.Map<Color>(coloresCreacion);
            context.Add(color);
            await context.SaveChangesAsync();
            return Ok();
        }

        
    }
}
