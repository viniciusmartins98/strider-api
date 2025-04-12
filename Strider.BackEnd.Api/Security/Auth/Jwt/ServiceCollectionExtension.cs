using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Strider.BackEnd.Api.Security.Auth.Jwt
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddJwtBearerAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = configuration.GetValue<string>("Jwt:Issuer");
            var audience = configuration.GetValue<string>("Jwt:Audience");
            var jwtSecret = configuration.GetValue<string>("Jwt:Secret");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                        ClockSkew = TimeSpan.Zero // Remove delay of token when expire
                    };
                });
            return services;
        }
    }
}
