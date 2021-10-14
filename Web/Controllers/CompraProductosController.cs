using CommonCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CompraProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompraProductos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ComprasProductos
                .Include(c => c.Compra)
                .Include(c => c.Producto)
                .IgnoreQueryFilters();
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CompraProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraProducto = await _context.ComprasProductos
                .Include(c => c.Compra)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compraProducto == null)
            {
                return NotFound();
            }

            return View(compraProducto);
        }

        // GET: CompraProductos/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto");
            return View();
        }

        // POST: CompraProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cantidad,PrecioUnitarioFinal,CompraId,ProductoId,Id,EstaBorrado")] CompraProducto compraProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id", compraProducto.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", compraProducto.ProductoId);
            return View(compraProducto);
        }

        // GET: CompraProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraProducto = await _context.ComprasProductos.FindAsync(id);
            if (compraProducto == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id", compraProducto.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", compraProducto.ProductoId);
            return View(compraProducto);
        }

        // POST: CompraProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cantidad,PrecioUnitarioFinal,CompraId,ProductoId,Id,EstaBorrado")] CompraProducto compraProducto)
        {
            if (id != compraProducto.CompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraProductoExists(compraProducto.CompraId))
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
            ViewData["CompraId"] = new SelectList(_context.Compras, "Id", "Id", compraProducto.CompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", compraProducto.ProductoId);
            return View(compraProducto);
        }

        // GET: CompraProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraProducto = await _context.ComprasProductos
                .Include(c => c.Compra)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.CompraId == id);
            if (compraProducto == null)
            {
                return NotFound();
            }

            return View(compraProducto);
        }

        // POST: CompraProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraProducto = await _context.ComprasProductos.FindAsync(id);
            _context.ComprasProductos.Remove(compraProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraProductoExists(int id)
        {
            return _context.ComprasProductos.Any(e => e.CompraId == id);
        }
    }
}
