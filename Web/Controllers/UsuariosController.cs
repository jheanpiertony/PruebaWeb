using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        #region Campos
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        #endregion

        #region Propiedades
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public UsuariosController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _context = context;
        }
        #endregion

        // GET: Usuarios
        public IActionResult Index()
        {
            List<ApplicationUser> listaUsuarios = _context.Users.ToList();
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
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,UserName,PasswordHash,PhoneNumber,Apellidos,Nombres,Genero")] ApplicationUser applicationUser)
        {
            var oldUserASP = await _userManager.FindByEmailAsync(applicationUser.Email);
            if (oldUserASP != null)
            {
                ModelState.AddModelError("Ya esta registrado", "Usuario ya registrado");
            }

            var userASP = new ApplicationUser
            {
                Email = applicationUser.Email,
                Nombres = applicationUser.Nombres,
                Apellidos = applicationUser.Apellidos,
                Genero = applicationUser.Genero,
                UserName = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber,                
            };

            var result = await _userManager.CreateAsync(userASP, applicationUser.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

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