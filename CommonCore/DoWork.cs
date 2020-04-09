using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonCore
{
    [Table("DoWork")]
    public class DoWork : Entidad
    {
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
    }
}
