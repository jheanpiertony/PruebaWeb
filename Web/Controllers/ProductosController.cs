using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommonCore;
using CommonCore.Helpers;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImagenHelper _imagenHelper;

        public ProductosController(ApplicationDbContext context, IImagenHelper imagenHelper)
        {
            _context = context;
            _imagenHelper = imagenHelper;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var listaProducto = _context.Productos;                                 
            return View(await listaProducto.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var pathImagen = string.Empty;
                
                if (producto.Logo != null)
                {
                    pathImagen = await _imagenHelper.CargarImagenAsync(producto.Logo, "Productos");
                }
                else
                {
                    pathImagen = _imagenHelper.CargarImagenDefecto("ProductoDefecto", "Productos");
                }

                producto.ImagenURL = pathImagen;
                _context.Add(producto);
                
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate") || ex.InnerException.Message.Contains("duplicada "))
                    {
                        ModelState.AddModelError(string.Empty, $"El producto {producto.NombreProducto} ya existe!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreProducto,Precio")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        ModelState.AddModelError(string.Empty, $"El producto {producto.NombreProducto} fue borrado!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate") || ex.InnerException.Message.Contains("duplicada "))
                    {
                        ModelState.AddModelError(string.Empty, $"El producto {producto.NombreProducto} ya existe!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }                
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
