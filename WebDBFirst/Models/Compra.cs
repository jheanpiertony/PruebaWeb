using System;
using System.Collections.Generic;

namespace WebDBFirst.Models
{
    public partial class Compra
    {
        public Compra()
        {
            CompraProducto = new HashSet<CompraProducto>();
        }

        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public string ApplicationUserId { get; set; }
        public bool EstaBorrado { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual ICollection<CompraProducto> CompraProducto { get; set; }
    }
}
