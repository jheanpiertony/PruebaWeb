using System;
using System.Collections.Generic;

namespace WebDBFirst.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CompraProducto = new HashSet<CompraProducto>();
        }

        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
        public bool EstaBorrado { get; set; }

        public virtual ICollection<CompraProducto> CompraProducto { get; set; }
    }
}
