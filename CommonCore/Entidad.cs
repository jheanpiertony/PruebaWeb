using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonCore
{
    public class Entidad
    {
        public Entidad()
        {
            EstaBorrado = false;
        }

        [Key]
        public int Id { get; set; }
        public bool EstaBorrado { get; set; }
    }
}
