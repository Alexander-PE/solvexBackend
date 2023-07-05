namespace solvex.Entidades
{
    public class ProductoDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto producto { get; set; }
        public int ColorId { get; set; }
        public Color color { get; set; }
        public decimal Precio { get; set; }
        public int UsuarioId { get; set; }
    }
}
