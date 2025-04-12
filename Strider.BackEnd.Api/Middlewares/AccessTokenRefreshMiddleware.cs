using Strider.BackEnd.Api.Security.Auth.Jwt;
using Strider.BackEnd.Application.Models.Users;
using Strider.BackEnd.Application.UserContext;

namespace Strider.BackEnd.Api.Middlewares
{
    public class AccessTokenRefreshMiddleware(
        RequestDelegate _next,
        ILogger<AccessTokenRefreshMiddleware> logger,
        JwtHandler jwtHandler
    )
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User?.Identity?.IsAuthenticated == false)
            {
                await _next(context);
                return;
            }
            var accessToken = jwtHandler.RefreshJwtToken();
            context.Response.Headers.Remove("x-access-token");
            context.Response.Headers.Add("x-access-token", accessToken);
            await _next(context);
        }
    }
}
