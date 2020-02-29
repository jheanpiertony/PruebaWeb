using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonCore
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Género")]
        public Genero Genero { get; set; }
    }
}
