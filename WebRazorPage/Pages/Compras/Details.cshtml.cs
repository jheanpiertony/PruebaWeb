using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommonCore;

namespace WebRazorPage.Pages.Compras
{
    public class DetailsModel : PageModel
    {
        private readonly CommonCore.ApplicationDbContext _context;

        public DetailsModel(CommonCore.ApplicationDbContext context)
        {
            _context = context;
        }

        public Compra Compra { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compra = await _context.Compras.FirstOrDefaultAsync(m => m.Id == id);

            if (Compra == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
