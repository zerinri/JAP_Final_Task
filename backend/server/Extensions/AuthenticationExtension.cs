using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace NormativeApp.Api.Extensions
{
    public static class AuthenticationExtension
    {
        public static void SetupAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                System.Text.Encoding.ASCII.GetBytes(
                                    configuration.GetSection("AppSettings:Token").Value
                                )
                            ),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}