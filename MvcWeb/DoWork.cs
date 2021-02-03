namespace MvcWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoWork")]
    public partial class DoWork
    {
        public int Id { get; set; }

        public bool EstaBorrado { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Fecha { get; set; }

        public string Evento { get; set; }
    }
}
