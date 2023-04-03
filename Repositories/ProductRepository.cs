using Microsoft.EntityFrameworkCore;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorks2019Context _context;

        public ProductRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public TopProduct GetProducto()
        {
            try
            {
                var query = (from detail in _context.SalesOrderDetails
                              join product in _context.Products on detail.ProductId equals product.ProductId
                              group detail by product.Name into g
                              orderby g.Sum(d => d.OrderQty) descending
                              select new TopProduct
                              {
                                  ProductName = g.Key,
                                  TotalOrders = g.Sum(d => d.OrderQty)
                              }).FirstOrDefault();

                return query;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _context.Products.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
