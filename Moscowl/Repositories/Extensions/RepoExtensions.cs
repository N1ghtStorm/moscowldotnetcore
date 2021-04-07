using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moscowl.Data;

namespace Moscowl.Repositories.Extensions
{
    public static class RepoExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<OwlDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString()), ServiceLifetime.Transient);
        }

        public static string GetConnectionString(this IConfiguration configuration)
        {
            return configuration["Connection"];
        }
    }
}