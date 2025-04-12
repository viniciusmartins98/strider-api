using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Strider.BackEnd.Application.UserContext;

namespace Strider.BackEnd.Api.Identity
{
    public class UserContext : IUserContext
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            var claimsPrincipal = httpContextAccessor.HttpContext.User;
            Id = int.Parse(claimsPrincipal.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? "0");
            Name = claimsPrincipal.FindFirstValue(JwtRegisteredClaimNames.Name);
            Email = claimsPrincipal.FindFirstValue(JwtRegisteredClaimNames.Email);
        }
    }
}
