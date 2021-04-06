using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSignalRChat.Data;
using WebSignalRChat.Interfaces;
using WebSignalRChat.Services;

namespace WebSignalRChat
{
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> chathub;
        private readonly ApplicationDbContext dbContext;
        private readonly IDataCambioUsuario sqlDependencyService;

        public ChatController(IHubContext<ChatHub> chathub, ApplicationDbContext dbContext, IDataCambioUsuario sqlDependencyService)
        {
            this.chathub = chathub;
            this.dbContext = dbContext;
            this.sqlDependencyService = sqlDependencyService;
        }
        public IActionResult Index()
        {
            chathub.Clients.All.SendAsync("ReceiveMessage", "Administrador", "Un nuevo usuario entro al ChatHub");
            return View();
        }
        [Authorize]
        public IActionResult SqlDependency()
        {
            sqlDependencyService.Configuracion();
            var usuario = HttpContext.User.Identity.Name;
            chathub.Clients.All.SendAsync("ReceiveMessage", "Administrador", $"{usuario} entro al ChatHub");
            return View();
        }
        [Authorize]
        public IActionResult ChatPrivado()
        {
            var usuariosRegistrado = dbContext.Users.ToList();
            var listaUsuariosRegistrados = new List<SelectListItem>();
            
            foreach (var item in usuariosRegistrado)
            {
                listaUsuariosRegistrados.Add(new SelectListItem() 
                {
                    Text = item.Email.ToString(),
                    Value = item.Id,
                });
            }

            ViewBag.ListaUsuariosRegistrados = listaUsuariosRegistrados;
            var usuario = HttpContext.User.Identity.Name;
            chathub.Clients.All.SendAsync("ReceiveMessage", "Administrador", $"{usuario} entro al un chat privado ChatHub");
            return View();
        }

    }
}
