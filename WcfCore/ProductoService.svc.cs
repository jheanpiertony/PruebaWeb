using CommonCore.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using AutoMapper;
using CommonCore;

namespace WcfCore
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProductoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ProductoService.svc o ProductoService.svc.cs en el Explorador de soluciones e inicie la depuración. 
    [ServiceBehaviorAttribute(IncludeExceptionDetailInFaults = true)]
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoService;
        MapperConfiguration _configMapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductoWCF, Producto>());

        public ProductoService(IProductoRepository productoService)
        {
            _productoService = productoService;
        }
        public async Task<List<ProductoWCF>> Productos()//public List<ProductoWCF> Productos()
        {
            var listadoProducto = await _productoService.OdtenerListaProducto();
            var mapper = new Mapper(_configMapper);
            var listadoProductoWCF = mapper.Map<List<ProductoWCF>>(listadoProducto);
            return listadoProductoWCF;
        }
    }
}
