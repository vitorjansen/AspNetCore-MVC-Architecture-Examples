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
            // Simulação de um dado recebido pelo usuário para ser validado em Privacy.
            var filme = new Filme
            {
                Titulo = "Um filme",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };


            return RedirectToAction("Privacy", filme); // Retorno IActionResult.
        }

        [Route("Privacy")]
        public IActionResult Privacy(Filme filme)
        {
            if (ModelState.IsValid) // Validação da Model
            {

            }

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
