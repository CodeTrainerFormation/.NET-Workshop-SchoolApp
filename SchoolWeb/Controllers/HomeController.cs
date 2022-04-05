using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using SchoolWeb.Services;
using System.Diagnostics;

namespace SchoolWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITools tools;

        public HomeController(ILogger<HomeController> logger, ITools tools)
        {
            this.logger = logger;
            this.tools = tools;
        }

        public IActionResult Index()
        {
            Debug.WriteLine(this.tools.GetTodayDate());

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