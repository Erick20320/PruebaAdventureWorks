using Microsoft.AspNetCore.Mvc;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Controllers
{
    public class PersonController : Controller
    {
        private readonly IGenericRepository _repository;

        public PersonController(IGenericRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Persons()
        {
            var persons = _repository.GetClientes();

            return View(persons);
        }
    }
}
