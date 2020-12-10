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
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly SanatorioContext db;

        public LoginController(ILogger<LoginController> logger, SanatorioContext contexto) {
            this._logger = logger;
            this.db = contexto;
        }

        public IActionResult InicioSesion(){
            return View();
        }

        public IActionResult Login(string mail, string contraseña){
            Usuario usuarioLogin = db.Usuario.FirstOrDefault(usuario => usuario.Mail == mail);
            if(usuarioLogin != null){
                if(usuarioLogin.Contraseña == contraseña){
                    AgregarUsuarioASession(usuarioLogin);
                    ViewBag.UsuarioLogeado = true;
                    ViewBag.Usuario = usuarioLogin;
                    return RedirectToAction("IndexUser", "User");
                }else{
                    ViewBag.ErrorEnLogin = true;
                    return View("InicioSesion");
                }
            }else{
                ViewBag.ErrorEnLogin = true;
                return View("InicioSesion");
            }
        }

        private JsonResult AgregarUsuarioASession(Usuario usuarioLogin) {
           HttpContext.Session.Set<Usuario>("UsuarioLogueado", usuarioLogin);
            return Json(usuarioLogin);
        }

        public IActionResult Registro(){
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
