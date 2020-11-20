using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Sanatorio.Models;

namespace Proyecto.Controllers
{
    public class LogginController : Controller
    {
        private readonly ILogger<LogginController> _logger;
        private readonly SanatorioContext db;

        public LogginController(ILogger<LogginController> logger, SanatorioContext contexto) {
            this._logger = logger;
            this.db = contexto;
        }

        public IActionResult Registro() {
            return View();
        }

        public IActionResult InicioSesion(){
            return View();
        }

        
        [HttpPost]
        public IActionResult RegistrarUsuario(string mail, string nombre, string apellido, string contraseña) {
            Usuario nuevoUsuario = new Usuario{
                Mail = mail,
                Nombre = nombre,
                Apellido = apellido,
                Contraseña = contraseña
            };

            db.Usuario.Add(nuevoUsuario);
            db.SaveChanges();
            return View("InicioSesion");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
