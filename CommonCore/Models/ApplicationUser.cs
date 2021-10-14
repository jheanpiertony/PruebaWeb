using CommonCore.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonCore
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            FechaNacimiento = DateTime.Now;
        }
        [Display(Name = "Contraseña")]
        public override string PasswordHash
        {
            get => base.PasswordHash;
            set => base.PasswordHash = value;
        }

        [Required]
        [PersonalData]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [PersonalData]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Género")]
        public Genero Genero { get; set; }

        //[Required]
        public string UrlFoto { get; set; }

        [NotMapped]
        [Display(Name = "Foto de perfil")]
        public IFormFile FotoPerfil { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [ValidarFechaNacimiento(ErrorMessage ="La {0} debe ser menor a la fecha actual")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public List<Compra> Compras { get; set; }

        [NotMapped]
        [Display(Name = "Nombre y apellido")]
        public string NombreApellido
        {
            get => $"{Nombres} {Apellidos}";
        }

        [Display(Name = "Nro. de telefono")]
        public override string PhoneNumber
        {
            get => base.PhoneNumber;
            set => base.PhoneNumber = value;
        }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
