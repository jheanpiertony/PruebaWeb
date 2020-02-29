using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonCore
{
    [Table("Producto")]
    public class Producto : Entidad
    {
        public Producto()
        {
            ImagenURL = string.Empty;
        }

        [Display(Name ="Imagen del producto")]
        public string ImagenURL { get; set; }

        [NotMapped]
        [Display(Name ="Logo")]
        public IFormFile Logo { get; set; }

        [Display(Name = "Nombre del producto")]
        [Required]
        public string NombreProducto { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        [Required]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        public List<CompraProducto> ComprasProductos { get; set; }
    }
}