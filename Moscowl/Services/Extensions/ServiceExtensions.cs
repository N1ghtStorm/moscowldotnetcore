using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Moscowl.Config;
using System;
using System.Linq;
using System.Text;

namespace Moscowl.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            var secret = GetRandomSecret();

            services.AddSingleton<GlobalConfig>(new GlobalConfig {
                Secret = secret
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        private static string GetRandomSecret()
        {
            var random = new Random();
            var random_num_len = random.Next(30, 50);
            var chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890!@#$%^&*+_=";
            var secret = new string(Enumerable.Repeat(chars, random_num_len).Select(x => x[random.Next(x.Length)]).ToArray());
            return secret;
        }
    }
}
