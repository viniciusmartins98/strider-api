using Microsoft.IdentityModel.Tokens;
using Strider.BackEnd.Api.Security.Auth.Jwt.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Strider.BackEnd.Api.Security.Auth.Jwt
{
    public class JwtHandler
    {
        public string GenerateJwtToken(JwtModel jwtModel)
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
