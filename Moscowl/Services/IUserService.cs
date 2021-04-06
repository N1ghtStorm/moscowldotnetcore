using Moscowl.DTOs;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public interface IUserService
    {
        Task CreateUser(UserForRegisterDTO user_dto);
    }
}
