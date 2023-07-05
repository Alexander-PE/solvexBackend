using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using solvex.DTOs;
using solvex.Entidades;

namespace solvex.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public UsuariosController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(UsuariosCreacionDTO usuarioCreacion)
        {
            var usuario = mapper.Map<Usuario>(usuarioCreacion);

            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> Put(int id, UsuariosCreacionDTO usuarioCreacion)
        {
            var user = await context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
            if(user is null)
            {
                return NotFound();
            }
            user.Nombre = usuarioCreacion.Nombre;
            user.RoleId = usuarioCreacion.RoleId;
            user.Password = usuarioCreacion.Password; 

            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var user = await context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
            context.Usuarios.Remove(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var user = await context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<Usuario>> Get(string nombre)
        {
            var user = await context.Usuarios.SingleOrDefaultAsync(x => x.Nombre == nombre);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


    }
}
