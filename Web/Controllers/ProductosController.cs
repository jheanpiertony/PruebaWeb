using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommonCore;
using CommonCore.Helpers;
using CommonCore.Repositories;
using AutoMapper;

namespace Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImagenHelper _imagenHelper;
        private IRepositorio<Producto> _repositorio;
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductosController(
            ApplicationDbContext context, 
            IImagenHelper imagenHelper,
            IRepositorio<Producto> repositorio,
            IProductoRepository productoRepository,
            IMapper mapper)
        {
            _context = context;
            _imagenHelper = imagenHelper;
            _repositorio = repositorio;
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        // GET: Productos
        public IActionResult Index()
        {
            var parametros = new ParametrosDeQuery<Producto>(1, 5);
            parametros.OrderBy = x => x.NombreProducto;
            var listadoProductos = _repositorio.EncontrarPor(parametros);
            return View(listadoProductos);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _listadoProductos = await _productoRepository.OdtenerListaProducto();
            var producto = _listadoProductos.FirstOrDefault(m => m.Id == id);
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
