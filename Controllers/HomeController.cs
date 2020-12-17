using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Sanatorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanatorioContext db;

        public HomeController(ILogger<HomeController> logger, SanatorioContext contexto)
        {
            _logger = logger;
            this.db = contexto;
        }

        public IActionResult Index(){
            Usuario usuarioLogueado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(usuarioLogueado != null){
                ViewBag.NombreUsuario = usuarioLogueado.Nombre;
            }
            ViewBag.Notas = db.Nota.ToList();
            return View();
        }

        public IActionResult Institucional()
        {
            return View();
        }

        public IActionResult Historia()
        {
            return View();
        }


         public IActionResult Prestaciones()
        {
            return View();
        }
         public IActionResult Coberturas() {
             ViewBag.ObrasSociales = db.ObraSocial.Where(os => os.Estado == "Activa").OrderBy(o => o.Nombre).ToList();
             ViewBag.Planes = db.Plan.ToList();
            return View();
        }

         public IActionResult Contacto() {
            Usuario usuarioLogeado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(usuarioLogeado != null){                
                ViewBag.Nombre = usuarioLogeado.Nombre;
                ViewBag.Mail = usuarioLogeado.Mail;
            }
            return View();
        }

        [HttpPost]
        public IActionResult EnviarConsulta(string nombre, string mail, string telefono, string consulta) {
            try {

                MailAddress to = new MailAddress(mail);
                MailAddress from = new MailAddress("sanatoriofavaloro@gmail.com");
                MailMessage message = new MailMessage(from, to);

                message.Subject = "Recibimos tu consulta";
                message.Body = "<h3>Hola " + nombre + "</h3>" +
                                    "<div><p>Gracias por comunicarte con nuestro sanatorio, te informamos que recibimos tu consulta satisfactoriamente y te estaremos contestando por este medio lo mas pronto posible.</p></div>" +
                                    "<div><p>Saludos Coridales</p></div>" +
                                    "<div><p><i class=" + "fas fa-users" + "></i> Servicio de atención a pacientes del Sanatorio Favaloro.</p></div>";

                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("sanatoriofavaloro@gmail.com", "favaloro123");           
                client.Send(message);
            }
            catch (SmtpException ex) {
                Console.WriteLine(ex.ToString());
            }

            return Redirect("/Home/Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
