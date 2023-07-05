using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex.DTOs;
using solvex.Entidades;

namespace solvex.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public RolesController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(RolesCreacionDTO rolesCreacion)
        {
            var role = mapper.Map<Role>(rolesCreacion);
            context.Add(role);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return await context.Roles.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Role>>> Get(int id)
        {
            var rol = context.Roles.SingleOrDefaultAsync(x => x.Id == id);
            if(rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }
    }
}
