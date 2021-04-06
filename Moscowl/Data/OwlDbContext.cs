using Microsoft.EntityFrameworkCore;
using Moscowl.Models;
using System.Reflection;

namespace Moscowl.Data
{
    public class OwlDbContext : DbContext
    {
        public OwlDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
