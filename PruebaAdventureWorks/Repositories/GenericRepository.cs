using Microsoft.EntityFrameworkCore;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly AdventureWorksContext _context;

        public GenericRepository(AdventureWorksContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetClientes()
        {
            return _context.Customers.ToList();
        }
    }
}
