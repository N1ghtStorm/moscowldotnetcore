using Microsoft.EntityFrameworkCore;
using Moscowl.Models;
using System.Reflection;

namespace Moscowl.Data
{
    public class OwlDbContext : DbContext
    {
        public OwlDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerSeason> PlayerSeasons { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Feature> Feature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}