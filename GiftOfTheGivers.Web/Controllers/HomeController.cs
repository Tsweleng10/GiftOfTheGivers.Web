using System.Diagnostics;
using GiftOfTheGivers.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.Web.Controllers
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
        public IActionResult About()
        {
            ViewData["Title"] = "About - Gift of the Givers";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact - Gift of the Givers";
            return View();
        }
    }
}
