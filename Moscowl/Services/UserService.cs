using Moscowl.DTOs;
using Moscowl.Models;
using Moscowl.Repositories;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(UserForRegisterDTO user_dto)
        {
            var user = User.MapDto(user_dto, CreatePasswordHash);
            await _repository.CreateUser(user);
        }

        private bool VarifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                    return false;
            }
            return true;
        }

        private (byte[], byte[]) CreatePasswordHash(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            return (hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)), hmac.Key);
        }
    }
}
