// WeatherForecastApi.Tests
using POC_Simple_API_Test.Controllers;
using POC_Simple_API_Test;
using Moq;
using Microsoft.Extensions.Logging;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastApi.Tests
{
    public class WeatherForecastControllerTests
    {

        // Test 1 - Route 1
        [Fact]
        public void Get_ReturnsWeatherForecasts()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.NotEmpty(result);
        }

        // Test 2 - Route 2
        [Fact]
        public void GetByDays_ReturnsWeatherForecastsForSpecifiedDays()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);
            int days = 10;

            // Act
            var result = controller.GetByDays(days);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.NotEmpty(result);
            Assert.Equal(days, result.Count());
        }
    }
}
