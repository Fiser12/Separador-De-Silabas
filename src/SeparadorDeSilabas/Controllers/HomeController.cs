using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace SeparadorDeSilabas.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TextoViewModel());
        }
        [HttpPost]
        public IActionResult Index(TextoViewModel input)
        {
            if(!ModelState.IsValid)
            {
                return View(input);
            }
            input.textoProcesado = SeparadorFrases.ProcesadorDelTexto.ProcesarTexto(input.texto, input.col);
            return View(input);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
