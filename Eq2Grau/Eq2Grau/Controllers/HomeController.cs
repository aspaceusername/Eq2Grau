using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using static System.Math;

namespace Eq2Grau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(String A, String B, String C)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || string.IsNullOrEmpty(C))
            {
                //tentar com viewData
                //criar sec��es dentro do bag para guardar conteudo

                ViewBag.Mensagem ="valor nulo";
                return View();
            }
            float a;
            float b;
            float c;
            if (!float.TryParse(A, out a)) {
                ViewBag.Mensagem = "A is not a number";
            }
            if(!float.TryParse(B, out b)) {
                ViewBag.Mensagem = "B is not a number";
            }
            if(!float.TryParse(C, out c)) {
                ViewBag.Mensagem = "C is not a number";
            }
            /* Algorithm
             * Primeiro a fazer � validar inputs, apenas s�o aceites numero e n�o texto
             * Se tiver tudo bem fazemos o algortimo e enviamos a solu��o, se n�o, send error message
             * if A=/=0 ok, else not ok !
             * Determinar x1 e x2, s�o as ra�zes
             */

            if (a != 0) { 
            double rootPlus = ((b * -1) + Math.Sqrt((b * b) - 4 * a * c)) / 2 * a;
            double rootMinus = ((b * -1) - Math.Sqrt((b * b) - 4 * a * c)) / 2 * a;
            
            ViewBag.x1 = rootPlus;
            ViewBag.x2 = rootMinus;
                
            } else {
                ViewBag.Mensagem="a cannot be Zero";
            }
            return View();
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
