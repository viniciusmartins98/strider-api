using Microsoft.AspNetCore.Mvc;
using Strider.BackEnd.Application.Queries;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase<WeatherForecastController>
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            _logger.LogInformation("Get weather forecast requested");
            return await Mediator.Send(new GetWeatherForecastQuery());
        }
    }
}
