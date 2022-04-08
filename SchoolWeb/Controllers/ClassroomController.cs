using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Data;
using SchoolWeb.Models;

namespace SchoolWeb.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        // GET: ClassroomController
        public ActionResult Index()
        {
            //Classroom classroom = new Classroom()
            //{
            //    ClassroomId = 1,
            //    Name = "Salle Bill Gates",
            //    Floor = 2,
            //    Corridor = "rouge",
            //    Students = new List<Student>()
            //    {
            //        new Student()
            //        {
            //            PersonId = 1,
            //            FirstName = "Ted",
            //            LastName = "Mosby",
            //            Age = 35,
            //            Average = 12.0,
            //            IsClassDelegate = true
            //        },
            //        new Student()
            //        {
            //            PersonId = 2,
            //            FirstName = "Barney",
            //            LastName = "Stinson",
            //            Age = 38,
            //            Average = 10.0,
            //            IsClassDelegate = false
            //        },
            //        new Student()
            //        {
            //            PersonId = 3,
            //            FirstName = "Lily",
            //            LastName = "Aldrin",
            //            Age = 36,
            //            Average = 16.0,
            //            IsClassDelegate = false
            //        }
            //    }
            //};

            //ViewBag.ClassroomId = classroom.ClassroomId;

            Classroom classroom = context.Classrooms.Include(c => c.Students)
                                                    .Include(c => c.Teacher)
                                                    .Single(c => c.ClassroomId == 1);

            ViewBag.ClassroomId = 1;

            return View(classroom);
        }
    }
}
