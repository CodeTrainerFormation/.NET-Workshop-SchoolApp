using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using SchoolWeb.Services;
using System.Diagnostics;

namespace SchoolWeb.Controllers
{
    //[Route("Private")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITools tools;

        public HomeController(ILogger<HomeController> logger, ITools tools)
        {
            this.logger = logger;
            this.tools = tools;
        }

        //[Route("")]
        //[Route("Index")]
        //[HttpGet("Index")]
        public IActionResult Index()
        {
            Debug.WriteLine(this.tools.GetTodayDate());

            return View();
        }

        //[Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpPost("Today")]
        //public IActionResult Today()
        //{
        //    return Content(this.tools.GetTodayDate());
        //}

        [HttpGet("Today")]
        public IActionResult Today()
        {
            return Content(this.tools.GetTodayDate());
        }

        //[Route("Today")]
        //public IActionResult Today()
        //{
        //    return Content(this.tools.GetTodayDate());
        //}

        //[Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}