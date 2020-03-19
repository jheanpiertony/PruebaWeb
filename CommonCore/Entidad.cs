using System.ComponentModel.DataAnnotations;

namespace CommonCore
{
    public  abstract class Entidad
    {
        public Entidad()
        {
            EstaBorrado = false;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name ="Esta activo")]
        public bool EstaBorrado { get; set; }
    }
}
