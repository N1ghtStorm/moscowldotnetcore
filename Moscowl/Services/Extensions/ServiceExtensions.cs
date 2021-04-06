using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Moscowl.Config;
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
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        private static string GetRandomSecret()
        {
            return "asdasd3d3d3dQASDASRQWERT3WQEER2";
        }
    }
}
