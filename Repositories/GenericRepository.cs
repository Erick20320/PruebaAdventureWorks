using Microsoft.EntityFrameworkCore;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Repository
{
    public class GenericRepository : IGenericRepository<Person>
    {
        private readonly AdventureWorks2019Context _context;

        public GenericRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetClientes()
        {
            return _context.People.ToList();
        }
    }
}
