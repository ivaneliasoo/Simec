using app.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace app.web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ILogger<PacientesController> _logger;

        public PacientesController(ILogger<PacientesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(new PacienteModel());
        }

        public IActionResult Privacy()
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
