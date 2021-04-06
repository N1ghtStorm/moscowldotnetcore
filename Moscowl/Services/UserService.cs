using Microsoft.IdentityModel.Tokens;
using Moscowl.Config;
using Moscowl.DTOs;
using Moscowl.Exceptions;
using Moscowl.Models;
using Moscowl.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly GlobalConfig _globalconfig;

        public UserService(GlobalConfig globalConfig)
        {
            _globalconfig = globalConfig;
        }

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(UserDto user_dto)
        {
            var user = User.MapDto(user_dto, CreatePasswordHash);
            await _repository.CreateUser(user);
        }

        public async Task<TokenDto> LoginUser(UserDto user_dto)
        {
            var created_user = await _repository.GetUser(user_dto.Name);
            var is_valid = VarifyPasswordHash(user_dto.Password, created_user.PasswordHash, created_user.PasswordSalt);

            if (!is_valid)
            {
                throw new NotFoundException($"user {user_dto.Name} not found");
            }

            var refresh_token = CreateToken(_globalconfig.Secret, 1_728_000);
            var access_token = CreateToken(_globalconfig.Secret, 300);
            return new TokenDto() { 
                Refresh = refresh_token,
                Access = access_token
            };
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

        private string CreateToken(string secret, int life_time)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescr = new SecurityTokenDescriptor
            {
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescr);
            return tokenHandler.WriteToken(token);
        }
    }
}
