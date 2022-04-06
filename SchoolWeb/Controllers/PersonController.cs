using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using System.Net;

namespace SchoolWeb.Controllers
{
    public class PersonController : Controller
    {
        private List<Person> people;

        public PersonController()
        {
            this.people = new List<Person>()
            {
                new Person()
                {
                    PersonId = 1,
                    FirstName = "Ted",
                    LastName = "Mosby",
                    Age = 35
                },
                new Person()
                {
                    PersonId = 2,
                    FirstName = "Barney",
                    LastName = "Stinson",
                    Age = 38
                },
                new Person()
                {
                    PersonId = 3,
                    FirstName = "Lily",
                    LastName = "Aldrin",
                    Age = 36
                }
            };
        }

        public IActionResult Index()
        {
            // list of person (model)
            return View(this.people);
        }

        [HttpGet("Person/Index/VM")]
        public IActionResult IndexWithViewModel(int currentPage = 1, int itemPerPage = 2)
        {
            PersonListViewModel model = new PersonListViewModel()
            {
                People = this.people,
                CurrentPage = currentPage,
                ItemPerPage = itemPerPage,
                NumberOfPages = this.people.Count() / itemPerPage
            };

            // list of person (model)
            return View(model);
        }

        [HttpGet("Person/Index/VB")]
        public IActionResult IndexWithViewBag(int currentPage = 1, int itemPerPage = 2)
        {
            //this.ViewData["myKey"] = "myvalue";
            //this.ViewData["myPerson"] = new Person() { FirstName = "Robin" };

            ViewBag.MyKey = "mynewvalue";

            ViewBag.CurrentPage = currentPage;
            ViewBag.ItemPerPage = itemPerPage;
            ViewBag.NumberOfPages = this.people.Count() / itemPerPage;

            return View(this.people);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            // find a person (model)
            Person? p = this.people.SingleOrDefault(p => p.PersonId == id);

            if(p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        
    }
}
