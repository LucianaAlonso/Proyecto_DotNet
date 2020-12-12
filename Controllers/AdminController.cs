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
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly SanatorioContext db;

        public AdminController(ILogger<AdminController> logger, SanatorioContext contexto) {
            this._logger = logger;
            this.db = contexto;
        }

        public IActionResult InicioSesionAdmin(){
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdmin(string usuario, string contraseña){
            Admin adminLogin = db.Admin.FirstOrDefault(admin => admin.Usuario == usuario);
            if(adminLogin != null){
                if(adminLogin.Contraseña == contraseña){
                    AgregarAdminASession(adminLogin);
                    return View("AdminHome");
                }else{
                    ViewBag.ErrorEnLogin = true;
                    return View("InicioSesionAdmin");
                }
            }else{
                ViewBag.ErrorEnLogin = true;
                return View("InicioSesionAdmin");
            }
        }

        public IActionResult AdminHome(){
            return View();
        }

        public IActionResult VerMedicos(){
            ViewBag.Medicos = db.Medico.ToList();
            return View();
        }
        public IActionResult AgregarOS(){
            return View();
        }

        private JsonResult AgregarAdminASession(Admin adminLogin) {
           HttpContext.Session.Set<Admin>("AdminLogueado", adminLogin);
            return Json(adminLogin);
        }

        public IActionResult Salir(){
            HttpContext.Session.Remove("UsuarioLogeado");
            return RedirectToAction("InicioSesion", "Login") ;
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}