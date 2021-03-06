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
            ViewBag.Especialidades = db.Especialidad.OrderBy(e => e.Nombre).ToList();
            ViewBag.Medicos = db.Medico.Include(m => m.Especialidad).Include(m => m.RolEnEspecialidad).ToList();
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
