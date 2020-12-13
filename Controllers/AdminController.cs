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

        [HttpPost]
        public IActionResult EditarMedico(int ID, string especialidad, string rolEnEspecialidad)
        {
            Medico medico = db.Medico.FirstOrDefault(n => n.ID == ID);
            medico.Especialidad = especialidad;
            medico.RolEnEspecialidad = rolEnEspecialidad;

            db.Medico.Update(medico);
            db.SaveChanges();

            return Redirect("VerMedicos");
        }

        public IActionResult EliminarMedico(int ID)
        {
            Medico medico = db.Medico.FirstOrDefault(m => m.ID == ID);
            
            db.Medico.Remove(medico);
            db.SaveChanges();

            return Redirect("VerMedicos");
        }

        public IActionResult ResultadoDelProceso(){
            return View();
        }

        [HttpPost]
        public IActionResult AgregarMedico(string nombreYApellido, string especialidad, string rolEnEspecialidad) {
            Medico nuevoMedico = new Medico{
                NombreYApellido = nombreYApellido,
                Especialidad = especialidad,
                RolEnEspecialidad = rolEnEspecialidad
            };

            ViewBag.Info = " El profesional " + nombreYApellido + " con la especialidad " + especialidad;
            db.Medico.Add(nuevoMedico);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

        

        public IActionResult VerObrasSociales(){
            ViewBag.ObrasSociales = db.ObraSocial.ToList();
            return View();
        }

        public IActionResult EditarObraSocial(int ID, string nombre, string web, string estado) {
            ObraSocial obraSocial = db.ObraSocial.FirstOrDefault(os => os.ID == ID);
            obraSocial.Nombre = nombre;
            obraSocial.PaginaWeb = web;
            obraSocial.Estado = estado;

            db.ObraSocial.Update(obraSocial);
            db.SaveChanges();

            return Redirect("VerObrasSociales");
        }

        public IActionResult EliminarObraSocial(int ID) {
            ObraSocial obraSocial = db.ObraSocial.FirstOrDefault(os => os.ID == ID);
            
            db.ObraSocial.Remove(obraSocial);
            db.SaveChanges();

            return Redirect("VerObrasSociales");
        }

        public IActionResult AgregarDatos(){
            return View();
        }

        public IActionResult AgregarObraSocial(string nombre, string web, string estado){
            ObraSocial obraSocial = db.ObraSocial.FirstOrDefault(os => os.Nombre == nombre);
            if(obraSocial != null){
                ViewBag.Error = true;
                return View("ResultadoDelProceso");
            }
            ObraSocial nuevaOS = new ObraSocial{
                Nombre = nombre,
                PaginaWeb = web,
                Estado = estado
            };

            ViewBag.Info = "La obra social " + nombre;
            db.ObraSocial.Add(nuevaOS);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

        private JsonResult AgregarAdminASession(Admin adminLogin) {
           HttpContext.Session.Set<Admin>("AdminLogueado", adminLogin);
            return Json(adminLogin);
        }

        public IActionResult Salir(){
            HttpContext.Session.Remove("AdminLogueado");
            return RedirectToAction("InicioSesion", "Login") ;
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}