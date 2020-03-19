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
    public class IndexModel : PageModel
    {
        private readonly CommonCore.ApplicationDbContext _context;

        public IndexModel(CommonCore.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Compra> Compra { get;set; }

        public async Task OnGetAsync()
        {
            Compra = await _context.Compras.ToListAsync();
        }
    }
}
