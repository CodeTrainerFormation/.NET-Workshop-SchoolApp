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

        public IActionResult Index()
        {
            return View(teachers);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            Teacher? teacher = teachers.SingleOrDefault(p => p.PersonId == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return View(teacher);

            teacher.PersonId = 5;
            teachers.Add(teacher);

            return RedirectToAction(nameof(Details), new { id = teacher.PersonId });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            // find a teacher (model)
            Teacher? teacher = teachers.SingleOrDefault(t => t.PersonId == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(int id, Teacher teacher)
        {
            if (id != teacher.PersonId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(teacher);

            Teacher? teacherToUpdate = teachers.SingleOrDefault(p => p.PersonId == teacher.PersonId);

            if (teacherToUpdate == null)
                return NotFound();

            teacherToUpdate.FirstName = teacher.FirstName;
            teacherToUpdate.LastName = teacher.LastName;
            teacherToUpdate.Age = teacher.Age;
            teacherToUpdate.HiringDate = teacher.HiringDate;
            teacherToUpdate.Discipline = teacher.Discipline;

            return RedirectToAction(nameof(Details), new { id = teacher.PersonId });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            Teacher? teacher = teachers.SingleOrDefault(p => p.PersonId == id);

            if (teacher == null)
                return NotFound();

            return View(teacher);
        }

        [HttpPost, ActionName(nameof(Delete))]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            Teacher? teacher = teachers.SingleOrDefault(p => p.PersonId == id);

            if (teacher == null)
                return NotFound();

            teachers.Remove(teacher);

            return RedirectToAction(nameof(Index));
        }
    }
}
