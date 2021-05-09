using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonCore
{
    [Table("DoWork")]
    public class DoWork : Entidad
    {
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
    }
}
