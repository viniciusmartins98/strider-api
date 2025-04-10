using MediatR;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Application.Queries
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
