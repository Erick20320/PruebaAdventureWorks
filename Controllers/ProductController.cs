using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;
using System.Data;

namespace PruebaAdventureWorks.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult ProductsInfo()
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

        public IActionResult TopProduct()
        {
            var products = _repository.GetProducto();

            return View(products);
        }
    }
}
