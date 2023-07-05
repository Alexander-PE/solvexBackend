using System.ComponentModel.DataAnnotations;

namespace solvex.DTOs
{
    public class ProductosCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;

        [StringLength(maximumLength: 150)]
        public string? ImagenUrl { get; set; }
        public string? Descripcion{ get; set; }
        public int UsuarioId { get; set; }
        public decimal Precio { get; set; }
        public int ColorId { get; set; }
    }
}
