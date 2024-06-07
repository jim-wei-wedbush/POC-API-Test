// WeatherForecastController.cs
using Microsoft.AspNetCore.Mvc;

namespace POC_Simple_API_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // Route 1: GET - GetWeatherForecast
        // Generate 5 random WeatherForecast objects
        // Input: None
        // Output: Array of 5 WeatherForecast objects
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // Route 2: GET - GetByDays, 
        // Generate {days} random WeatherForecast objects
        // Input: days (int)
        // Output: Array of {days} WeatherForecast objects
        [HttpGet("days/{days}")]
        public IEnumerable<WeatherForecast> GetByDays(int days)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        // Route 3: GET - GetAverageTemperature,
        // Calculate the average temperature of the next {days} days
        // Input: days (int)
        // Output: Average temperature (double)
        [HttpGet("average-temperature/{days}")]
        public double GetAverageTemperature(int days)
        {
            var forecasts = GetByDays(days);
            return forecasts.Average(f => f.TemperatureC);
        }

        // Route 5: GET - GetHottestDay,
        // Find the hottest day in the next {days} days
        // Input: days (int)
        // Output: Hottest day (WeatherForecast object)
        [HttpGet("hottest-day/{days}")]
        public WeatherForecast GetHottestDay(int days)
        {
            var forecasts = GetByDays(days);
            return forecasts.OrderByDescending(f => f.TemperatureC).First();
        }

    }
}
