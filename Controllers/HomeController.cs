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

        public IActionResult Index()
        {
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
             ViewBag.ObrasSociales = db.ObraSocial.ToList();
             ViewBag.Planes = db.Plan.ToList();
            return View();
        }

         public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult NotaUno(){
            return View();
        }

        public IActionResult NotaDos(){
            return View();
        }

        public IActionResult NotaTres(){
            return View();
        }


        [HttpPost]
        public IActionResult EnviarConsulta(string nombre, string mail, string telefono, string consulta) {

            MailAddress to = new MailAddress(mail);
            MailAddress from = new MailAddress("sanatoriofavaloro@gmail.com");
            MailMessage message = new MailMessage(from, to);

                message.Subject = "Recibimos tu consulta";
                message.Body = "<h3>Hola " + nombre + "</h3>" +
                                "<div><p>Gracias por comunicarte con nuestro sanatorio, te informamos que recibimos tu consulta satisfactoriamente y te estaremos contestando por este medio lo mas pronto posible.</p></div>" +
                                "<div><p>Saludos Coridales</p></div>" +
                                "<div><p><i class=" + "fas fa-users" + "></i> Servicio de atención a pacientes del Sanatorio Favaloro.</p></div>";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("sanatoriofavaloro@gmail.com", "favaloro123"),
                    EnableSsl = true
                }; 

                try
                {  
                    client.Send(message);
                }
                catch (SmtpException ex)
                {
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
