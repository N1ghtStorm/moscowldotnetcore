using Microsoft.EntityFrameworkCore;
using Moscowl.Models;

namespace Moscowl.Data
{
    public class OwlDbContext : DbContext
    {
        public OwlDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
