using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommonCore
{
    public enum Genero
    {
        [Description("Para el sexo femenino ")]
        [Display(Name ="Femenino")]
        Femenino = 0,
        [Description("Masculino")]
        Masculino = 1,
        [Description("No definido"), Display(Name = "No definido")]
        NoDefinido = 2,
    }
}
