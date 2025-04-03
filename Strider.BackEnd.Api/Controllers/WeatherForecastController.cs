using Microsoft.AspNetCore.Mvc;
using Strider.BackEnd.Application.Repositories;
using Strider.BackEnd.Domain.Entities;

namespace Strider.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync([FromServices] IWeatherForecastRepository repository)
        {
            return await repository.ListAsync();
        }
    }
}
