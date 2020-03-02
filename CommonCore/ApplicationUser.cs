﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonCore
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Género")]
        public Genero Genero { get; set; }

        public List<Compra> Compras { get; set; }
        
        [NotMapped]
        [Display(Name = "Nombre y apellido")]
        public string NombreApellido { get => $"{Nombres} {Apellidos}"; }
        
        [Display(Name = "Nro. de telefono")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
    }
}
