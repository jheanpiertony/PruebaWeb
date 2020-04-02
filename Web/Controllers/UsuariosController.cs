using AutoMapper;
using CommonCore;
using CommonCore.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        #region Campos
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IImagenHelper _imagenHelper;
        private readonly EnumService _enumService;
        private readonly IMapper _mapper;
        #endregion

        #region Propiedades
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public UsuariosController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IConfiguration configuration, 
            ApplicationDbContext context,
            IImagenHelper imagenHelper,
            EnumService enumService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _context = context;
            _imagenHelper = imagenHelper;
            _enumService = enumService;
            _mapper = mapper;
        }
        #endregion

        // GET: Usuarios
        public IActionResult Index()
        {
            List<ApplicationUser> listaUsuarios = _context.Users.OrderBy(na => na.NombreApellido).ToList();
            return View(listaUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var listadoGenero= _enumService.ToListSelectListItem<Genero>().OrderBy(x => x.Text);
            ViewBag.Genero = listadoGenero;
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser applicationUser)
        {
            var usuarioExistente = await _userManager.FindByEmailAsync(applicationUser.Email);
            if (usuarioExistente != null)
            {
                ModelState.AddModelError("Ya esta registrado", "Usuario ya registrado");
            }

            var fotoPerfilPath = string.Empty;

            if (applicationUser.FotoPerfil != null)
            {
                fotoPerfilPath = await _imagenHelper.CargarImagenAsync(applicationUser.FotoPerfil, "FotoPerfil");
            }
            else
            {
                fotoPerfilPath = _imagenHelper.CargarImagenDefecto("FotoPerfilDefecto", "FotoPerfil");
            }

            applicationUser.UserName = applicationUser.Email;
            applicationUser.UrlFoto = fotoPerfilPath;

            var result = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            var listadoGenero= _enumService.ToListSelectListItem<Genero>().OrderBy(x => x.Text);
            ViewBag.Genero = listadoGenero;

            return View(applicationUser);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}