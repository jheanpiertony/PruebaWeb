using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CommonCore;
using Microsoft.EntityFrameworkCore;

namespace WebRazorPage.Pages.Compras
{
    public class CreateModel : PageModel
    {
        private readonly CommonCore.ApplicationDbContext _context;

        #region Propiedades
        [BindProperty]
        public Compra Compra { get; set; }
        //[BindProperty]
        //public SelectList ListaApplicationUser { get; private set; }
        //[BindProperty]
        //public SelectList ListaProductos { get; private set; }
        //[BindProperty(SupportsGet = true)]
        [BindProperty] 
        public List<Producto> ListaProductosPartical { get; private set; }
        //[BindProperty(SupportsGet = true)]
        [BindProperty]
        public string ProductoSeleccionado { get; set; }
        #endregion

        #region Constructor
        public CreateModel(CommonCore.ApplicationDbContext context)
        {
            _context = context;
            //ProductoSeleccionado = string.Empty;
            //ListaProductosPartical = new List<Producto>();
        } 
        #endregion

        public IActionResult OnGet()
        {            
            ViewData["ListaApplicationUser"] = new SelectList(_context.Users.ToList(), "Id", "NombreApellido");
            ViewData["ListaProductos"] = new SelectList(_context.Productos.OrderBy(np => np.NombreProducto).ToList(), "Id", "NombreProducto");
            return Page();
        }        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Compras.Add(Compra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //public void OnPostListaProductosPartical()
        //{

        //}
        //public void OnPostListaProductosPartical(int IdProducto)
        //{

        //} 
        //public void OnPostListaProductosPartical(string IdProducto)
        //{

        //}
        //public void OnPostListaProductosPartical(SelectList IdProducto)
        //{

        //}
        
    }
}