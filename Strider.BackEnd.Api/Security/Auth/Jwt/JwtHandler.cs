using Microsoft.IdentityModel.Tokens;
using Strider.BackEnd.Api.Security.Auth.Claims;
using Strider.BackEnd.Api.Security.Auth.Jwt.Models;
using Strider.BackEnd.Application.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Strider.BackEnd.Api.Security.Auth.Jwt
{
    public class JwtHandler(ClaimsHandler claimsHandler, IConfiguration configuration)
    {
        public AuthTokenResponse GenerateAuthTokenResponse(UserModel user)
        {
            return new AuthTokenResponse
            {
                AccessToken = this.GenerateJwtToken(new JwtModel
                {
                    Claims = claimsHandler.GetClaimsFromUser(user),
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
    }
}
