using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Models;

namespace RazorPizzeria.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<PizzaOrder2> PizzaOrder2s { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): 
            base(options)
        {

        }
    }
}
