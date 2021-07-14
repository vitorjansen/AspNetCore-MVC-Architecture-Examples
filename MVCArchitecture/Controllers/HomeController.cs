using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCArchitecture.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("Index")] //sobrecarga de rotas.
        [Route("Index/{id:guid}")] // rota com parâmetros e definição do tipo de dado.
        public IActionResult Index(string id)
        {
            return View();
        }

        [Route("Privacy")]
        public IActionResult Privacy(Filme filme)
        {
            return View();
        }

        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
