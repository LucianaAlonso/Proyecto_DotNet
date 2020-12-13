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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly SanatorioContext db;

        public UserController(ILogger<UserController> logger, SanatorioContext contexto) {
            this._logger = logger;
            this.db = contexto;
        }

        public IActionResult MisTurnos(){
            return View();
        }

        public IActionResult TurnosOnline(){
            Usuario usuarioLogeado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            ViewBag.Nombre = usuarioLogeado.Nombre;
            ViewBag.Mail = usuarioLogeado.Mail;
            return View();
        }

        public IActionResult MiPerfil(){
            Usuario usuarioLogeado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            ViewBag.Nombre = usuarioLogeado.Nombre;
            ViewBag.Apellido = usuarioLogeado.Apellido;
            ViewBag.Mail = usuarioLogeado.Mail;
            ViewBag.ObraSocial = usuarioLogeado.ObraSocial;
            ViewBag.Contraseña = usuarioLogeado.Contraseña;
            ViewBag.ObrasSociales = db.ObraSocial.ToList();
            return View();
        }

        public IActionResult Transaccion(){
            return View();
        }

        public IActionResult EditarUsuario(string mail, string nombre, string apellido, string obraSocial, string contraseña){
            Usuario usuario = db.Usuario.FirstOrDefault(u => u.Mail == mail);
            usuario.Mail = mail;
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.ObraSocial = obraSocial;
            usuario.Contraseña = contraseña;

            db.Usuario.Update(usuario);
            db.SaveChanges();
            return View("Transaccion");
        }

        public IActionResult Salir(){
            HttpContext.Session.Remove("UsuarioLogueado");
            return RedirectToAction("InicioSesion", "Login") ;
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}