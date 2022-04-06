using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Models;
using System.Net;

namespace SchoolWeb.Controllers
{
    public class PersonController : Controller
    {
        private static List<Person>? people;

        public PersonController()
        {
            if (people == null || !people.Any())
            {
                people = new List<Person>()
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
        }

        public IActionResult Index()
        {
            // list of person (model)
            return View(people);
        }

        [HttpGet("Person/Index/VM")]
        public IActionResult IndexWithViewModel(int currentPage = 1, int itemPerPage = 2)
        {
            PersonListViewModel model = new PersonListViewModel()
            {
                People = people,
                CurrentPage = currentPage,
                ItemPerPage = itemPerPage,
                NumberOfPages = people.Count() / itemPerPage
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
            ViewBag.NumberOfPages = people.Count() / itemPerPage;

            return View(people);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            // find a person (model)
            Person? p = people.SingleOrDefault(p => p.PersonId == id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if(!ModelState.IsValid)
                return View(person);

            // insert a person in db
            // inserted person with id 5
            person.PersonId = 5;
            people.Add(person);

            return RedirectToAction("Details", new { id = 5 });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            // find a person (model)
            Person? p = people.SingleOrDefault(p => p.PersonId == id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(int id, Person person)
        {
            if (id != person.PersonId)
                return BadRequest();

            Person? personToUpdate = people.SingleOrDefault(p => p.PersonId == person.PersonId);

            if (personToUpdate == null)
                return NotFound();

            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.Age = person.Age;

            return RedirectToAction("Details", new { id = person.PersonId });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            // find a person (model)
            Person? p = people.SingleOrDefault(p => p.PersonId == id);

            if (p == null)
                return NotFound();

            return View(p);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            //if (!User.Identity.IsAuthenticated || !User.IsInRole("admin"))
            //    return Unauthorized();

            if (id == null || id <= 0)
                return BadRequest();

            // find a person (model)
            Person? p = people.SingleOrDefault(p => p.PersonId == id);

            if (p == null)
                return NotFound();

            people.Remove(p);

            return RedirectToAction("Index");
        }
    }
}
