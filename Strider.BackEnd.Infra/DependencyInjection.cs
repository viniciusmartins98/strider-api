using Microsoft.Extensions.DependencyInjection;
using Strider.BackEnd.Infra.Repositories;

namespace Strider.BackEnd.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            return services.AddRepositories();
        }
    }
}
