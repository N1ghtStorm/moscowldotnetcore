using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moscowl.Data;

namespace Moscowl.Repositories.Extensions
{
    public static class RepoExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<OwlDbContext>(opt => opt.UseNpgsql("asdasdas"), ServiceLifetime.Transient);
        }
    }
}
