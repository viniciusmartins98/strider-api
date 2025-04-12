using Strider.BackEnd.Application.Models.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Strider.BackEnd.Api.Security.Auth.Claims
{
    public class ClaimsHandler
    {
        public ClaimsIdentity GetClaimsIdentity(UserModel user)
        {
            List<Claim> claims = GetClaimsFromUser(user);
            return new ClaimsIdentity(claims, "Basic");
        }

        public List<Claim> GetClaimsFromUser(UserModel user)
        {
            return [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            ];
        }
    }
}
