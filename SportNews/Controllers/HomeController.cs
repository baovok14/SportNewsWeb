using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportNews.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportNews.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult DetailsBaiBao()
        {
            return View();
        }
        public IActionResult BongRo()
        {
            return View();
        }
        public IActionResult BongChuyen()
        {
            return View();
        }
        public IActionResult CauLong()
        {
            return View();
        }
        public IActionResult BongBan()
        {
            return View();
        }
        public IActionResult BoiLoi()
        {
            return View();
        }
        public IActionResult Billiards()
        {
            return View();
        }
    }
}
