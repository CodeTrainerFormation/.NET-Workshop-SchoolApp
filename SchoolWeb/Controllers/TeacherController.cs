using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class TeacherController : Controller
    {
        private static List<Teacher>? teachers;

        public TeacherController()
        {
            if (teachers == null || !teachers.Any())
            {
                teachers = new List<Teacher>()
                {
                    new Teacher()
                    {
                        PersonId = 1,
                        FirstName = "Ted",
                        LastName = "Mosby",
                        Age = 35,
                        Discipline = "Architect",
                        HiringDate = new DateTime(2008, 12, 30)
                    },
                    new Teacher()
                    {
                        PersonId = 2,
                        FirstName = "Barney",
                        LastName = "Stinson",
                        Age = 38,
                        Discipline = "Economy",
                        HiringDate = new DateTime(2020, 01, 25)
                    },
                    new Teacher()
                    {
                        PersonId = 3,
                        FirstName = "Lily",
                        LastName = "Aldrin",
                        Age = 36,
                        Discipline = "Generalist",
                        HiringDate = new DateTime(2016, 02, 21)
                    }
                };
            }
        }

        // CRUD

        public IActionResult Index()
        {


            return View();
        }
    }
}
