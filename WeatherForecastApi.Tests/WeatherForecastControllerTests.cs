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

        [Fact]
        public void Get_ReturnsWeatherForecasts()
        {
            // AAA Pattern
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
    }
}
