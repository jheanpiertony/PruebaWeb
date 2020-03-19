using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommonCore;

namespace WebRazorPage.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly CommonCore.ApplicationDbContext _context;

        public DeleteModel(CommonCore.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);

            if (Producto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Producto = await _context.Productos.FindAsync(id);

            if (Producto != null)
            {
                _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
