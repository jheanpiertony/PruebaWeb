using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProductoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        void DoWork();
        //[OperationContract]
        //List<Producto>
        
    }
    
}
