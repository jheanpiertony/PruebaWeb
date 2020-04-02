using CommonCore.Repositories;
using Unity;
using Unity.Wcf;

namespace WcfCore
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // configure container
            container
                .RegisterType<IProductoRepository, ProductoRepository>()
                .RegisterType<IProductoService, ProductoService>();
        }
    }
}