using Microsoft.AspNetCore.Mvc;
using PruebaAdventureWorks.DataContext;

namespace PruebaAdventureWorks.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AdventureWorksContext _context;

        public CustomerController(AdventureWorksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Customers.ToList();
            return View(clientes);
        }
    }
}
