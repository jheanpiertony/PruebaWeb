using CommonCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDDWeb.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersona persona;

        public PersonaController(IPersona persona)
        {
            this.persona = persona;
        }
        public IActionResult Mujer()
        {
            //    persona.Caminar();
            var result = persona.Hablar();
            //    persona.Oir();
            return View();
        }
    }
}
