using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSignalRChat.Services;

namespace WebSignalRChat
{
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> chathub;

        public ChatController(IHubContext<ChatHub> chathub)
        {
            this.chathub = chathub;
        }
        public IActionResult Index()
        {
            chathub.Clients.All.SendAsync("ReceiveMessage", "Administrador", "Un nuevo usuario entro al ChatHub");
            return View();
        }
        public IActionResult SqlDependency()
        {
            chathub.Clients.All.SendAsync("ReceiveMessage", "Adminsitrador", "Un nuevo usuario entro al ChatHub");
            return View();
        }

    }
}
