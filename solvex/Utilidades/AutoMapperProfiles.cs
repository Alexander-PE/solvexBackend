using AutoMapper;
using solvex.DTOs;
using solvex.Entidades;

namespace solvex.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<ProductosCreacionDTO, Producto>();
            CreateMap<ColoresCreacionDTO, Color>();
            CreateMap<RolesCreacionDTO, Role>();
            CreateMap<ProductoDetallesCreacionDTO, ProductoDetalle>();
            CreateMap<UsuariosCreacionDTO, Usuario>();
        }
    }
}
