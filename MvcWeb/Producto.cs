namespace MvcWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            CompraProducto = new HashSet<CompraProducto>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        public string NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public string ImagenURL { get; set; }

        public bool EstaBorrado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompraProducto> CompraProducto { get; set; }
    }
}
