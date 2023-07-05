namespace solvex.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

    }
}
