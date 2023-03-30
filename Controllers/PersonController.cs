using Microsoft.AspNetCore.Mvc;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Controllers
{
    public class PersonController : Controller
    {
        private readonly IGenericRepository<Person> _repository;

        public PersonController(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var person = _repository.GetClientes();
            return View(person);
        }
    }
}
