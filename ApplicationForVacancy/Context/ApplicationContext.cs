using Microsoft.EntityFrameworkCore;
using ApplicationForVacancy.Models;

namespace ApplicationForVacancy.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

    }
    
}
