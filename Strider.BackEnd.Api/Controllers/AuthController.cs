using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Strider.BackEnd.Api.Security.Auth.Claims;
using Strider.BackEnd.Api.Security.Auth.Jwt;
using Strider.BackEnd.Api.Security.Auth.Jwt.Models;
using Strider.BackEnd.Application.Models.Users;
using Strider.BackEnd.Application.Queries.Auth;

namespace Strider.BackEnd.Api.Controllers
{
    public class AuthController : ApiControllerBase<AuthController>
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] AuthRequest request)
        {
            var user = await Mediator.Send(new GetUserByCredentialsQuery
            {
                Email = request.Email,
                Password = request.Password
            });
            if (user == null)
            {
                return Unauthorized();
            }
            Logger.LogInformation("Login request");
            return Ok(GetAuthResponse(user));
        }

        private AuthResponse GetAuthResponse(UserModel user)
        {
            var jwtHandler = HttpContext.RequestServices.GetRequiredService<JwtHandler>();
            var claimsHandler = HttpContext.RequestServices.GetRequiredService<ClaimsHandler>();
            return new AuthResponse
            {
                AccessToken = jwtHandler.GenerateJwtToken(new JwtModel
                {
                    Claims = claimsHandler.GetClaimsFromUser(user),
                    ExpirationMinutes = Configuration.GetValue<int>("Jwt:ExpirationMinutes"),
                    Audience = Configuration.GetValue<string>("Jwt:Audience"),
                    Issuer = Configuration.GetValue<string>("Jwt:Issuer"),
                    Secret = Configuration.GetValue<string>("Jwt:Secret")
                })
            };
        }
    }
}
