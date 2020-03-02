using CommonCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var listaCompras = await _context.Compras
                .Include(cp => cp.ComprasProductos).IgnoreQueryFilters()
                .Include(au => au.ApplicationUser).IgnoreQueryFilters()
                .Select(x => new Compra
                {
                    ApplicationUser = x.ApplicationUser,
                    ComprasProductos = x.ComprasProductos,
                    EstaBorrado = x.EstaBorrado,
                    FechaCompra = x.FechaCompra,
                    Id = x.Id,
                    NroItems = x.ComprasProductos.Count,
                    Total = x.ComprasProductos.Sum(puf => puf.PrecioUnitarioFinal),
                })
                .ToListAsync();

            return View(listaCompras);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError(string.Empty, $"Este registo no existe");
                return RedirectToAction(nameof(Index));
            }

            var compra = await _context.Compras
                .Include(cp => cp.ComprasProductos).IgnoreQueryFilters()
                .Include(au => au.ApplicationUser).IgnoreQueryFilters()
                .FirstOrDefaultAsync(m => m.Id == id);            

            if (compra == null)
            {
                ModelState.AddModelError(string.Empty, $"Este registo no existe");
                return RedirectToAction(nameof(Index));
            }

            var productos = _context.Productos;
            var listaProductos = compra.ComprasProductos.Select(p => productos.Find(p.ProductoId)).ToList();

            ViewData["ListaProductos"] = listaProductos;
            return View(compra);
        }

        public IActionResult Create()
        {
            ViewBag.ApplicationUser = new SelectList(_context.Users.ToList(),"Id", "NombreApellido");
            ViewBag.Productos = new SelectList(_context.Productos.OrderBy(np => np.NombreProducto).ToList(),"Id", "NombreProducto");
            return View(new Compra());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaCompra,Id,EstaBorrado")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return View(compra);
        }

        // POST: Compras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaCompra,Id,EstaBorrado")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}
