using Microsoft.IdentityModel.Tokens;
using Strider.BackEnd.Api.Security.Auth.Jwt.Models;
using Strider.BackEnd.Application.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Strider.BackEnd.Api.Security.Auth.Jwt
{
    public class JwtHandler(
        IConfiguration configuration,
        IHttpContextAccessor httpAccessor)
    {
        public AuthTokenResponse GenerateAuthTokenResponse(UserModel user)
        {
            return new AuthTokenResponse
            {
                AccessToken = this.GenerateJwtToken(new JwtModel
                {
                    Claims = GetClaimsFromUser(user),
                    ExpirationMinutes = configuration.GetValue<int>("Jwt:ExpirationMinutes"),
                    Audience = configuration.GetValue<string>("Jwt:Audience"),
                    Issuer = configuration.GetValue<string>("Jwt:Issuer"),
                    Secret = configuration.GetValue<string>("Jwt:Secret")
                })
            };
        }

        private string GenerateJwtToken(JwtModel jwtModel)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtModel.Secret));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtModel.Issuer,
                audience: jwtModel.Audience,
                claims: jwtModel.Claims,
                expires: DateTime.UtcNow.AddMinutes(jwtModel.ExpirationMinutes),
                signingCredentials: signingCredentials
            );

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        private List<Claim> GetClaimsFromUser(UserModel user)
        {
            return [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            ];
        }

        public string RefreshJwtToken()
        {
            if (httpAccessor.HttpContext.User?.Identity?.IsAuthenticated == false)
            {
                return string.Empty;
            }
            return GenerateJwtToken(new JwtModel
            {
                Claims = httpAccessor.HttpContext.User.Claims,
                ExpirationMinutes = configuration.GetValue<int>("Jwt:ExpirationMinutes"),
                Audience = configuration.GetValue<string>("Jwt:Audience"),
                Issuer = configuration.GetValue<string>("Jwt:Issuer"),
                Secret = configuration.GetValue<string>("Jwt:Secret")
            });
        }
    }
}
