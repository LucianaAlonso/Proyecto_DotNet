using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Sanatorio.Models;
using System.Net;
using System.Net.Mail;

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
            ViewBag.Medicos = db.Medico.OrderBy(o => o.Especialidad).ToList();
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
            
            ViewBag.Boton = "Medicos";
            ViewBag.URL = "/Admin/VerMedicos";
            ViewBag.Info = " El profesional " + nombreYApellido + " con la especialidad " + especialidad + " fue agregado con exito !";
            db.Medico.Add(nuevoMedico);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

        

        public IActionResult VerObrasSociales(){
            ViewBag.ObrasSociales = db.ObraSocial.OrderBy(o => o.Nombre).ToList();
            return View();
        }

        [HttpPost]
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

        [HttpPost]
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

            ViewBag.Boton = "Obras Sociales";
            ViewBag.URL = "/Admin/VerObrasSociales";
            ViewBag.Info = "La obra social " + nombre + " fue agregada con exito !" ;
            db.ObraSocial.Add(nuevaOS);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

        public IActionResult VerNotas(){
            ViewBag.Notas = db.Nota.ToList();
            return View("VerNotas");
        }

        [HttpPost]
        public IActionResult AgregarNota(string titulo, string cuerpo, string fecha, string imagen, string URLnota){
            Nota nuevaNota = new Nota{
                Titulo = titulo,
                Cuerpo = cuerpo,
                Fecha = fecha,
                URLImagen = imagen,
                URLNotaCompleta = URLnota
            };
            ViewBag.Boton = "Notas";
            ViewBag.URL = "/Admin/VerNotas";
            ViewBag.Info = "La nota " + titulo + " fue agregada con exito !";
            db.Nota.Add(nuevaNota);
            db.SaveChanges();
            return View("ResultadoDelProceso");
        }

        [HttpPost]
        public IActionResult EditarNota(int ID, string titulo, string cuerpo, string fecha, string imagen, string URLnota){
            Nota nota = db.Nota.FirstOrDefault(n => n.ID == ID);
            nota.Titulo = titulo;
            nota.Cuerpo = cuerpo;
            nota.Fecha = fecha;
            nota.URLImagen = imagen;
            nota.URLNotaCompleta = URLnota;

            db.Nota.Update(nota);
            db.SaveChanges();

            return Redirect("VerNotas");
        }

        public IActionResult EliminarNota(int ID){
            Nota nota = db.Nota.FirstOrDefault(n => n.ID == ID);
            
            db.Nota.Remove(nota);
            db.SaveChanges();

            return Redirect("VerNotas");
        }

        private JsonResult AgregarAdminASession(Admin adminLogin) {
           HttpContext.Session.Set<Admin>("AdminLogueado", adminLogin);
            return Json(adminLogin);
        }

        public IActionResult Salir(){
            HttpContext.Session.Remove("AdminLogueado");
            return RedirectToAction("InicioSesionAdmin") ;
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}