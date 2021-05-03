using Common.Services;
using IHostedService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IHostedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogerBDService logger;

        public HomeController(ILogerBDService logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.CraerLogs("Controlador Index");
            return View();
        }

        public IActionResult Privacy()
        {
            logger.CraerLogs("Controlador Privacy");            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
