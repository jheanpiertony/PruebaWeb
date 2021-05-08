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
        public virtual string ImagenURL { get; set; }

        [NotMapped]
        [Display(Name ="Logo")]
        public IFormFile Logo { get; set; }

        [Display(Name = "Nombre del producto")]
        [Required]
        public virtual string NombreProducto { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        [Required]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [DataType(DataType.Currency)]
        [Range(0,double.MaxValue)]
        public virtual decimal Precio { get; set; }

        public List<CompraProducto> ComprasProductos { get; set; }
    }
}