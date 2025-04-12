using System.Security.Claims;

namespace Strider.BackEnd.Api.Security.Auth.Jwt.Models
{
    public class JwtModel
    {
        public int ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
