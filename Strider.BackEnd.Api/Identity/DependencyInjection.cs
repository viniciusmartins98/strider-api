using Strider.BackEnd.Application.UserContext;

namespace Strider.BackEnd.Api.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserContext(this IServiceCollection services)
        {
            return services.AddTransient<IUserContext, UserContext>();
        }
    }
}
