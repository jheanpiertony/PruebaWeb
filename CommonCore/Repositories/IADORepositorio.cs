using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore.Repositories
{
    public interface IADORepositorio
    {
        Task<List<Producto>> ObtenerListadoProductos();
    }
}
