using CommonCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents
{
    public class ProductosViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ProductosViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var listaProductos = _context.Productos.Take(10).ToList();
            return View(listaProductos);
        }
    }
}
