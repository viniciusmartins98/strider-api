using Microsoft.AspNetCore.Mvc;
using Strider.BackEnd.Application.Queries.WeatherForecasts;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Api.Controllers
{
    public class WeatherForecastController : ApiControllerBase<WeatherForecastController>
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            Logger.LogInformation("Get weather forecast requested");
            return await Mediator.Send(new GetWeatherForecastQuery());
        }
    }
}
