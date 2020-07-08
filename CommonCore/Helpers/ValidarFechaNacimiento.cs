using System;
using System.ComponentModel.DataAnnotations;

namespace CommonCore.Helpers
{
    public class ValidarFechaNacimiento : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var fechaNacimiento = (DateTime)value;
            return fechaNacimiento < DateTime.Now;  
        }
    }
}
