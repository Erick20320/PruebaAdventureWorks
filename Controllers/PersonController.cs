using Microsoft.AspNetCore.Mvc;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
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

        public IActionResult Index()
        {
            var persons = _repository.GetClientes();

            return View(persons);
        }
    }
}
