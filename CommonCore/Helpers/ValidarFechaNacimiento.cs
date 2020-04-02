using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
