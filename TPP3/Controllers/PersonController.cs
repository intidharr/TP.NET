using Microsoft.AspNetCore.Mvc;
using TPP3.Models;

namespace TPP3.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/{id:int}")]
        public IActionResult Index(int id)
        {
            Personal_info Personal_info = new Personal_info();

            return View(Personal_info.GetPerson(id));
        }
        [Route("Person/all")]
        public IActionResult All()
        {
            Personal_info personal_Info = new Personal_info();

            return View(personal_Info.GetAllPerson());
        }
        [HttpGet]
        public IActionResult Search()
        {
            ViewBag.notFound = false;
            return View();
        }
        [HttpPost]
        public IActionResult Search(String first_name, String country)
        {
            Personal_info Personal_info = new Personal_info();
            List<Person> Persons = Personal_info.GetAllPerson();
            foreach (Person person in Persons)
            {
                if (person.FirstName == first_name && person.Country == country)
                {
                    return Redirect(person.Id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
    }
}
