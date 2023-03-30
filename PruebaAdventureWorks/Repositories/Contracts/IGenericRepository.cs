using PruebaAdventureWorks.Models;
using System.Collections.Generic;

namespace PruebaAdventureWorks.Repositories.Contracts
{
    public interface IGenericRepository
    {
        IEnumerable<Customer> GetClientes();
    }
}
