using Moscowl.DTOs;
using System;

namespace Moscowl.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public static User MapDto(UserDto dto, Func<string, (byte[], byte[])> hasher)
        {
            var (hash, salt) = hasher(dto.Password);
            return new User()
            {
                Name = dto.Password,
                PasswordHash = hash,
                PasswordSalt = salt
            };
        }
    }
}
