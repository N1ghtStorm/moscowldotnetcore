using Moscowl.Models;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUser(string name);
    }
}
