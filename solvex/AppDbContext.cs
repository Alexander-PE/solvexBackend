using Microsoft.EntityFrameworkCore;
using solvex.Entidades;

namespace solvex
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductoDetalle>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);
            modelBuilder.Entity<Role>().HasKey(p => p.Id);
            modelBuilder.Entity<Color>().HasKey(p => p.Id);


            modelBuilder.Entity<Producto>().Property(p => p.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Producto>().Property(p => p.ImagenUrl).HasMaxLength(500);

            modelBuilder.Entity<ProductoDetalle>().Property(p => p.Precio).HasPrecision(7,2);

            modelBuilder.Entity<Usuario>().Property(p => p.Nombre).HasMaxLength(50);

            modelBuilder.Entity<Role>().Property(p => p.Nombre).HasMaxLength(50);

            modelBuilder.Entity<Color>().Property(p => p.Nombre).HasMaxLength(50);

        }
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<ProductoDetalle> ProductoDetalles => Set<ProductoDetalle>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Color> Colores => Set<Color>();
    }
}
