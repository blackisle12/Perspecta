using Microsoft.AspNetCore.Mvc;
using Perspecta.Domain.Client.RapidApi;
using Perspecta.Service.Interface;

namespace Perspecta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IApiNinjaService _apiNinjaService;
        private readonly IRapidApiService _rapidApiService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IApiNinjaService apiNinjaService,
            IRapidApiService rapidApiService,
            ILogger<WeatherForecastController> logger)
        {
            _apiNinjaService = apiNinjaService;
            _rapidApiService = rapidApiService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string country = "US", int limit = 10, int days = 3)
        {
            try
            {
                var forecastResults = new List<ForecastResult>();
                var cities = await _apiNinjaService.GetCities(country, limit);

                foreach (var city in cities)
                {
                    var forecastResult = await _rapidApiService.GetWeatherForecast(city.Name!, days);

                    if (forecastResult != null)
                    {
                        forecastResults.Add(forecastResult);
                    }
                }

                return Ok(forecastResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "An error occured while processing your request. Please try again later");
            }
        }
    }
}
