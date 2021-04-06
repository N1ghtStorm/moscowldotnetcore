using Microsoft.EntityFrameworkCore;
using Moscowl.Data;
using Moscowl.Models;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OwlDbContext m_db_context;

        public UserRepository(OwlDbContext db_context)
        {
            m_db_context = db_context;
        }
        public async Task CreateUser(User user)
        {
            await m_db_context.AddAsync(user);
            await m_db_context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string name)
        {
            return await m_db_context.Users.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}