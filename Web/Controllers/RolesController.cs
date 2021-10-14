using CommonCore;
using CommonCore.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Web.Controllers
{
    public class RolesController : Controller
    {
        #region Campos
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IImagenHelper _imagenHelper;
        private readonly EnumService _enumService;
        #endregion

        #region Constructor
        public RolesController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IImagenHelper imagenHelper,
            EnumService enumService)
        {
            _userManager = userManager;
            _context = context;
            _imagenHelper = imagenHelper;
            _enumService = enumService;
        }
        #endregion

        // GET: Roles
        public IActionResult Index()
        {
            List<ApplicationRole> roles = _context.Roles.ToList();
            return View(roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationRole identityRole)
        {            
            var rolExistente = _context.Roles.Where(x => x.Name == identityRole.Name).FirstOrDefault();
            if (rolExistente != null)
            {
                ModelState.AddModelError("Ya esta registrado", "Rol ya registrado");
            }

            _context.Roles.Add(identityRole);
            var result = _context.SaveChanges();

            if (result != 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(identityRole);
        }
    }
}
