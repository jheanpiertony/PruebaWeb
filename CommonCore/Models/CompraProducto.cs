using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonCore
{
    [Table("CompraProducto")]
    public class CompraProducto : Entidad
    {
        [Display(Name = "Cantidad")]
        [Required]
        [Range(1, 10, ErrorMessage = "El valor {0} debe ser entre {1} y {2}.")]
        public int Cantidad { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        [Required]
        [Display(Name = "Precio unit.")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        [DataType(DataType.Currency)]
        [Range(0,double.MaxValue)]
        public decimal PrecioUnitarioFinal { get; set; }

        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}
