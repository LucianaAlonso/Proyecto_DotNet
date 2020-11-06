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
    public class InstitucionalController : Controller
    {
        private readonly ILogger<InstitucionalController> _logger;

        public InstitucionalController(ILogger<InstitucionalController> logger)
        {
            _logger = logger;
        }


        public IActionResult Historia()
        {
            return View();
        }

         public IActionResult Staff()
        {
            return View();
        }

         public IActionResult Autoridades()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
