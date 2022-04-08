using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Data;

namespace SchoolWeb.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly SchoolContext context;

        public DatabaseController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet("Db/Create")]
        public IActionResult CreateDatabase()
        {
            this.context.Database.EnsureCreated();

            return View();
        }

        [HttpGet("Db/Delete")]
        public IActionResult DeleteDatabase()
        {
            this.context.Database.EnsureDeleted();

            return View();
        }
    }
}
