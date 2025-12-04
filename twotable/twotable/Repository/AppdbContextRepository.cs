using Microsoft.EntityFrameworkCore;
using twotable.Models;

namespace twotable.Repository
{
    public class AppdbContextRepository : DbContext
    {
        public AppdbContextRepository(DbContextOptions<AppdbContextRepository> options) 
            : base(options) 
        { 
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
