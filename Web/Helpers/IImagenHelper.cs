using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Web.Helpers
{
    public interface IImagenHelper
    {
        Task<string> CargarImagenAsync(IFormFile imagenArchivo, string carpeta);
        string CargarImagenDefecto(string nombreArchivo, string carpeta);
    }
}
