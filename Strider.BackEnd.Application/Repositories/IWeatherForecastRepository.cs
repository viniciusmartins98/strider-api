using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Application.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> ListAsync();
    }
}
