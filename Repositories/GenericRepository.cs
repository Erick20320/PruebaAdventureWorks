using Microsoft.EntityFrameworkCore;
using PruebaAdventureWorks.DataContext;
using PruebaAdventureWorks.Models;
using PruebaAdventureWorks.Repositories.Contracts;

namespace PruebaAdventureWorks.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly AdventureWorks2019Context _context;

        public GenericRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public List<Person> GetClientes()
        {
            var query = from person in _context.People
                        join address in _context.Addresses on person.BusinessEntityId equals address.AddressId
                        select new Person
                        {
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            AddressLine1 = address.AddressLine1,
                        };

            return query.ToList();
        }
    }
}
