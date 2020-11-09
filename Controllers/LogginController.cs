using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class LogginController : Controller
    {
        private readonly ILogger<LogginController> _logger;

        public LogginController(ILogger<LogginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registro() {
            return View();
        }

        public IActionResult InicioSesion(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
