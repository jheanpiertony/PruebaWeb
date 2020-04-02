using System;
using System.Collections.Generic;

namespace WebDBFirst.Models
{
    public partial class CompraProducto
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Id { get; set; }
        public bool EstaBorrado { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitarioFinal { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
