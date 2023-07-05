using System.ComponentModel.DataAnnotations;

namespace solvex.DTOs
{
    public class ProductoDetallesCreacionDTO
    {
        public int ProductoId { get; set; }
        public int ColorId { get; set; }
        public decimal Precio { get; set; }
        public int UsuarioId { get; set; }

    }
}
