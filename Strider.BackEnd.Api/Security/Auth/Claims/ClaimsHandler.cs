using Strider.BackEnd.Application.Models.Users;
using System.Security.Claims;

namespace Strider.BackEnd.Api.Security.Auth.Claims
{
    public class ClaimsHandler
    {
        public ClaimsIdentity GetClaimsIdentity(UserModel user)
        {
            List<Claim> claims = [
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            ];
            return new ClaimsIdentity(claims, "Jwt");
        }

        public List<Claim> GetClaimsFromUser(UserModel user)
        {
            return [
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            ];
        }
    }
}
