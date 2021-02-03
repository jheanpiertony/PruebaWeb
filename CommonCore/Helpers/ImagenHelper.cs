using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CommonCore.Helpers
{
    public class ImagenHelper : IImagenHelper
    {
        public async Task<string> CargarImagenAsync(IFormFile imagenArchivo, string carpeta)
        {
            string guid = Guid.NewGuid().ToString();
            string file = $"{guid}.jpg";
            string path = Path.Combine(
                Environment.CurrentDirectory,
                $"wwwroot\\Imagenes\\{carpeta}",
                file);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await imagenArchivo.CopyToAsync(stream);
            }

            return $"~/Imagenes/{carpeta}/{file}";
        }

        public string CargarImagenDefecto(string nombreArchivo, string carpeta)
        {            
            string _nombreArchivo = $"{nombreArchivo}.jpg";
            return $"~/Imagenes/{carpeta}/{_nombreArchivo}";
        }
    }
}
