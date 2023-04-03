using PruebaAdventureWorks.Models;

namespace PruebaAdventureWorks.Repositories.Contracts
{
    public interface IProductRepository
    {
        TopProduct GetProducto();
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
    }
}
