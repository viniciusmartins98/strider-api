using MediatR;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Application.Queries.WeatherForecasts
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
