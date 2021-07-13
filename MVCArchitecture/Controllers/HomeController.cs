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
    [Route("rota-home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")] // rota vazia.
        [Route("rota-index")] //sobrecarga de rotas.
        [Route("rota-index/{id:guid}/numero:int")] // rota com parâmetros e definição do tipo de dado.
        public IActionResult Index(string id, string numero)
        {
            return View(); // Retorno de uma View.
        }

        [Route("privacy")]
        [Route("rota-privacy")]
        public IActionResult Privacy()
        {
            return Json("{'teste':'retornoJson'}"); // Retorno de um JSON.
        }

        [Route("erro")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
