using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lommeregnercore.Models;

namespace Lommeregnercore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculator cal)
        {
            int a, b;
            a = cal.Value1;
            b = cal.Value2;

            if (cal.Calulate == "+")
            {
                cal.Resultat = a + b;
            }
            else if(cal.Calulate == "-")
            {
                cal.Resultat = a - b;
            }
            else if (cal.Calulate == "*")
            {
                cal.Resultat = a * b;
            }
            else if (cal.Calulate == "/")
            {
                cal.Resultat = a / b;
            }

            ViewData["result"] = cal.Resultat;
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
