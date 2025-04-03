using Microsoft.Extensions.DependencyInjection;
using Strider.BackEnd.Application.Repositories;

namespace Strider.BackEnd.Infra.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}
