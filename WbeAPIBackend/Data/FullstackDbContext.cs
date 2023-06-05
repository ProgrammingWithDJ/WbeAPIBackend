using Microsoft.EntityFrameworkCore;
using WbeAPIBackend.Models;

namespace WbeAPIBackend.Data
{
    public class FullstackDbContext : DbContext
    {
        public FullstackDbContext(DbContextOptions options) : base (options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
