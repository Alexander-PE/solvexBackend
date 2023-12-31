﻿using System.ComponentModel.DataAnnotations;

namespace solvex.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagenUrl { get; set;}
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
