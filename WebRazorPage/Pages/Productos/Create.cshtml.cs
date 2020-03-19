using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CommonCore;
using CommonCore.Helpers;

namespace WebRazorPage.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly CommonCore.ApplicationDbContext _context;
        private readonly IImagenHelper _imagenHelper;

        public CreateModel(CommonCore.ApplicationDbContext context,
            IImagenHelper imagenHelper)
        {
            _context = context;
            _imagenHelper = imagenHelper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var pathImagen = string.Empty;

            if (ModelState.IsValid)
            {                
                if (Producto.Logo != null)
                {
                    pathImagen = await _imagenHelper.CargarImagenAsync(Producto.Logo, "Productos");
                }
                else
                {
                    pathImagen = _imagenHelper.CargarImagenDefecto("ProductoDefecto", "Productos");
                }

                Producto.ImagenURL = pathImagen;
                _context.Add(Producto);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate") || ex.InnerException.Message.Contains("duplicada "))
                    {
                        ModelState.AddModelError(string.Empty, $"El producto {Producto.NombreProducto} ya existe!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return Page();
        }
    }
}