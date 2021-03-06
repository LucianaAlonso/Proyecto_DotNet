using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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
            Usuario user = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            List<Turno> turnos = db.Turno.Include(t => t.Medico).Where(t => t.Paciente == user.Mail).ToList();
            if(turnos.Count() != 0){
                ViewBag.Turnos = turnos;
                return View();
            }
            ViewBag.SinTurnos = true;
            return View();
        }

        public IActionResult TurnosOnline(){
            Usuario usuarioLogeado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            ViewBag.Nombre = usuarioLogeado.Nombre;
            ViewBag.Mail = usuarioLogeado.Mail;
            return View();
        }

        public IActionResult CancelarTurno(int ID){
            Turno turno = db.Turno.FirstOrDefault(t => t.ID == ID);
            turno.Estado = "Cancelado";

            db.Turno.Update(turno);
            db.SaveChanges();
            return Redirect("MisTurnos");
        }

        public IActionResult MiPerfil(){
            Usuario usuarioLogeado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Usuario user = db.Usuario.FirstOrDefault(u => u.Mail == usuarioLogeado.Mail);
            ViewBag.Nombre = user.Nombre;
            ViewBag.Apellido = user.Apellido;
            ViewBag.Mail = user.Mail;
            ViewBag.ObraSocial = user.ObraSocial;
            ViewBag.Contraseña = user.Contraseña;
            ViewBag.ObrasSociales = db.ObraSocial.ToList();
            return View();
        }

        public IActionResult Transaccion(){
            return View();
        }

        public IActionResult EditarUsuario(string mail, string nombre, string apellido, string obraSocial, string contraseña){
            Usuario usuario = db.Usuario.FirstOrDefault(u => u.Mail == mail);
            usuario.ObraSocial = obraSocial;
            usuario.Contraseña = contraseña;

            db.Usuario.Update(usuario);
            db.SaveChanges();
            return View("Transaccion");
        }

        public IActionResult EliminarCuenta(string Mail){
            HttpContext.Session.Remove("UsuarioLogueado");
            Usuario usuario = db.Usuario.FirstOrDefault(u => u.Mail == Mail);
            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
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