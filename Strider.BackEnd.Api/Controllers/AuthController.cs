using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Strider.BackEnd.Api.Security.Auth.Jwt;
using Strider.BackEnd.Api.Security.Auth.Jwt.Models;
using Strider.BackEnd.Application.Queries.Auth;

namespace Strider.BackEnd.Api.Controllers
{
    public class AuthController : ApiControllerBase<AuthController>
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] AuthTokenRequest request)
        {
            var user = await Mediator.Send(new GetUserByCredentialsQuery
            {
                Email = request.Email,
                Password = request.Password
            });
            var jwtHandler = HttpContext.RequestServices.GetRequiredService<JwtHandler>();
            return user == null ? Unauthorized("Invalid credentials, user not found.") : Ok(jwtHandler.GenerateAuthTokenResponse(user));
        }
    }
}
