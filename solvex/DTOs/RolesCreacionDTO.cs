using System.ComponentModel.DataAnnotations;

namespace solvex.DTOs
{
    public class RolesCreacionDTO
    {
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; } = null!;
    }
}
