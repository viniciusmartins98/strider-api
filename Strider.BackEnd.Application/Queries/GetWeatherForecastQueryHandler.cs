using MediatR;
using Strider.BackEnd.Application.Repositories;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Application.Queries
{
    public class GetWeatherForecastQueryHandler(IWeatherForecastRepository repository) : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            return await repository.ListAsync();
        }
    }
}
