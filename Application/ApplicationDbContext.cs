using Microsoft.EntityFrameworkCore;
using practice_0502025.Entities;

namespace practice_0502025.Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Car> Cars { get; set; } // Add your other entities here
    }
}

