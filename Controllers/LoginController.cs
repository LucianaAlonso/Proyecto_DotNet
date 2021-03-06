using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Sanatorio.Models;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult Login(string mail, string contraseña){
            Usuario usuarioLogin = db.Usuario.FirstOrDefault(usuario => usuario.Mail == mail);
            if(usuarioLogin != null){
                if(usuarioLogin.Contraseña == contraseña){
                    TempData["Nombre"] = usuarioLogin.Nombre;
                    AgregarUsuarioASession(usuarioLogin);
                    return RedirectToAction("Index", "Home");
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
            ViewBag.ObrasSociales = db.ObraSocial.Where(os => os.Estado == "Activa").OrderBy(os => os.Nombre).ToList();
            return View();
        }

        
        [HttpPost]
        public IActionResult RegistrarUsuario(string mail, string nombre, string apellido, string obraSocial, string contraseña) {
            Usuario user = db.Usuario.FirstOrDefault(u => u.Mail == mail);
            if(user != null){
                ViewBag.MailRegistrado = true;
                return View("RegistroResult");
            }
            Usuario nuevoUsuario = new Usuario{
                Mail = mail,
                Nombre = nombre,
                Apellido = apellido,
                ObraSocial = obraSocial,
                Contraseña = contraseña
            };
            
            db.Usuario.Add(nuevoUsuario);
            db.SaveChanges();
            return View("RegistroResult");
        }

        public IActionResult RegistroResult(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
