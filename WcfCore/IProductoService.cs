using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfCore
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProductoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProductoService
    {
        //[OperationContract]
        //List<ProductoWCF> Productos();        
        [OperationContract]
        Task<List<ProductoWCF>> Productos();
    }

    [DataContract]
    public class ProductoWCF
    {
        public ProductoWCF()
        {
            ImagenURL = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name = "Esta activo")]
        [DataMember]
        public bool EstaBorrado { get; set; }

        [Display(Name = "Imagen del producto")]
        [DataMember]
        public virtual string ImagenURL { get; set; }

        [Display(Name = "Nombre del producto")]
        [Required]
        [DataMember]
        public virtual string NombreProducto { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        [Required]
        [DataMember]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [DataType(DataType.Currency)]
        public virtual decimal Precio { get; set; }
    }
}
