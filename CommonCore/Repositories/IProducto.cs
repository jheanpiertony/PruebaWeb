using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonCore.Repositories
{
    public interface IProducto
    {
        Task<List<Producto>> OdtenerListaProducto();
        Task CrearProducto(Producto producto);
        Task EditarProducto(Producto producto);
        Task EliminarProducto(int id);
    }
}
