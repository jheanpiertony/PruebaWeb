using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonCore
{
    [Table("Compra")]
    public class Compra : Entidad
    {
        public Compra()
        {
            NroItems = 0;
            Total = 0;
            FechaCompra = DateTime.Now;
        }

        [Required]
        [Display(Name = "Fecha de compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCompra { get; set; }

        public List<CompraProducto> ComprasProductos { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        [Display(Name = "Nro. Items")]
        public int NroItems { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total de compra")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}