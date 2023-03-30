using Microsoft.EntityFrameworkCore;
using PruebaAdventureWorks.Models;

namespace PruebaAdventureWorks.DataContext
{
    public class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
        {
        }

        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }

    }
}
