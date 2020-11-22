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
    public class InstitucionalController : Controller
    {
        private readonly ILogger<InstitucionalController> _logger;
        private readonly SanatorioContext db;

        public InstitucionalController(ILogger<InstitucionalController> logger, SanatorioContext contexto) {
            this._logger = logger;
            this.db = contexto;
        }


        public IActionResult Historia() {
            return View();
        }

         public IActionResult Staff() {
            ViewBag.CardiologiaClinica = db.Medico.Where(med => med.Especialidad == "Cardiología Clínica");
            ViewBag.CardiologiaIntervencionista = db.Medico.Where(med => med.Especialidad == "Cardiología Intervencionista"); 
            ViewBag.CirugiaCardiovascular = db.Medico.Where(med => med.Especialidad == "Cirugía Cardiovascular"); 
            ViewBag.CardiologiaPediatrica = db.Medico.Where(med => med.Especialidad == "Cardiología Pediátrica"); 
            ViewBag.Gastroenterologia = db.Medico.Where(med => med.Especialidad == "Gastroenterología"); 
            ViewBag.CirugiaToracica = db.Medico.Where(med => med.Especialidad == "Cirugía Torácica"); 

            ViewBag.CirugiaColumna = db.Medico.Where(med => med.Especialidad == "Cirugía de Columna"); 
            ViewBag.CirugiaGeneral = db.Medico.Where(med => med.Especialidad == "Cirugía General");
            ViewBag.CirugiaPlastica = db.Medico.Where(med => med.Especialidad == "Cirugía Plástica y Reparadora"); 
            ViewBag.Ginecologia = db.Medico.Where(med => med.Especialidad == "Ginecología"); 
            ViewBag.Hematologia = db.Medico.Where(med => med.Especialidad == "Hematología"); 
            ViewBag.Nefrologa = db.Medico.Where(med => med.Especialidad == "Nefrología"); 
            
            ViewBag.Neumonologia = db.Medico.Where(med => med.Especialidad == "Neumonología"); 
            ViewBag.Oncologia = db.Medico.Where(med => med.Especialidad == "Oncología"); 
            ViewBag.Traumatologia = db.Medico.Where(med => med.Especialidad == "Ortopedia y Traumatología"); 
            ViewBag.Otorrinolaringologia = db.Medico.Where(med => med.Especialidad == "Otorrinolaringología"); 
            ViewBag.Urologia = db.Medico.Where(med => med.Especialidad == "Urología"); 
            return View();
        }

         public IActionResult Autoridades() { 
            ViewBag.Autoridades = db.Autoridad.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
