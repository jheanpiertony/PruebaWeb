namespace MvcWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompraProducto")]
    public partial class CompraProducto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompraId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductoId { get; set; }

        public int Id { get; set; }

        public bool EstaBorrado { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitarioFinal { get; set; }

        public virtual Compra Compra { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
