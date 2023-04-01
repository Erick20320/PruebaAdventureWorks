using Microsoft.AspNetCore.Mvc;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index3()
        {
            var products = _repository.GetProductos();

            return View(products);
        }
    }
}
