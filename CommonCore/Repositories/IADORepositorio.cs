using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Repositories
{
    public interface IADORepositorio
    {
        Task<List<Producto>> ObtenerListadoProductos();
    }
}
