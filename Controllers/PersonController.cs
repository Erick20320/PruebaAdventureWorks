using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;
using System.Data;

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

        public ActionResult Index2()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-240T41M; Database=AdventureWorks2019; Integrated Security=true; Trusted_Connection=True; Trust Server Certificate=true;"))
            {
                SqlCommand command = new SqlCommand("SPGetAllProductsInfo", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductInfo product = new ProductInfo();
                    product.ProductName = reader["ProductName"].ToString();
                    product.Price = Convert.ToDecimal(reader["Price"]);
                    product.TotalStock = Convert.ToInt32(reader["TotalStock"]);
                    products.Add(product);
                }
            }
            return View(products);
        }

    }
}
