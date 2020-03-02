
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public List<SubCategoria> SubCategorias { get; set; }
    }
}
