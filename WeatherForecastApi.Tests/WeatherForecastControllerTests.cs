// WeatherForecastApi.Tests
using POC_Simple_API_Test.Controllers;
using POC_Simple_API_Test;

using Microsoft.Extensions.Logging;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace WeatherForecastApi.Tests
{
    public class WeatherForecastControllerTests
    {
        // Naming Convention: ClassName_MethodName_ExpectedResult


        private readonly WeatherForecastController _controller;
        private readonly ILogger<WeatherForecastController> _loggerMock;

        // Constructor to initialize System Under Test (SUT)
        public WeatherForecastControllerTests()
        {
            _loggerMock = A.Fake<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_loggerMock);
        }

        // Test 1 - Route 1 Get
        [Fact]
        public void WeatherForecastController_Get_ReturnsWeatherForecasts()
        {
            // Arrange
            //var loggerMock = A.Fake<ILogger<WeatherForecastController>>();
            //var controller = new WeatherForecastController(loggerMock);

            // Act
            var result = _controller.Get();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<WeatherForecast>>();
            result.Should().NotBeEmpty();

        }

        // Test 2 - Route 2 GetByDays(days)
        [Fact]
        public void WeatherForecastController_GetByDays_ReturnsWeatherForecastsForSpecifiedDays()
        {
            // Arrange
            //var loggerMock = A.Fake<ILogger<WeatherForecastController>>();
            //var controller = new WeatherForecastController(loggerMock);
            int days = 10;

            // Act
            var result = _controller.GetByDays(days);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<WeatherForecast>>();
            result.Should().HaveCount(days);
        }

        // Test 3 - Route 2 GetByDays(days) (Edge case: Negative days)
        // This one should fail
        [Fact]
        public void WeatherForecastController_GetByDays_ThrowsArgumentOutOfRangeExceptionWhenNegativeDays()
        {
            // Arrange
            //var loggerMock = A.Fake<ILogger<WeatherForecastController>>();
            //var controller = new WeatherForecastController(loggerMock);
            int days = -5;

            // Act & Assert
            _controller.Invoking(c => c.GetByDays(days)).Should().Throw<ArgumentOutOfRangeException>();
        }

        // Test 4 - Route 2 GetByDays(days) (Edge case: Zero days)
        [Fact]
        public void WeatherForecastController_GetByDays_ReturnsEmptyResultWhenZeroDays()
        {
            // Arrange
            //var loggerFake = A.Fake<ILogger<WeatherForecastController>>();
            //var controller = new WeatherForecastController(loggerFake);
            int days = 0;

            // Act
            var result = _controller.GetByDays(days);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        // Test 5 - Route 2 GetByDays(days) (Edge case: Large number of days)
        [Fact]
        public void WeatherForecastController_GetByDays_ReturnsWeatherForecastsForSpecifiedDaysWhenLargeNumberOfDays()
        {
            // Arrange
            //var loggerFake = A.Fake<ILogger<WeatherForecastController>>();
            //var controller = new WeatherForecastController(loggerFake);
            int days = 1000;

            // Act
            var result = _controller.GetByDays(days);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<WeatherForecast>>();
            result.Should().HaveCount(days);
        }
        // Test 6 - Route 2 (Edge case: Pass in String)
        // This one should fail

        //[Fact]
        //public void WeatherForecastController_GetByDays_ThrowsExceptionWhenStringIsPassed()
        //{
        //    // Arrange
        //    var loggerFake = A.Fake<ILogger<WeatherForecastController>>();
        //    var controller = new WeatherForecastController(loggerFake);
        //    string days = "invalid_string";

        //    // Act & Assert
        //    controller.Invoking(c => c.GetByDays(days)).Should().Throw<InvalidCastException>();
        //}

        // Test 7 - Route 3 GetAverageTemperature, Large number of days, testing to ensure average temperature is within range
        [Fact]
        public void WeatherForecastController_GetAverageTemperature_ReturnsAverageTemperatureWithinRangeWithLargeNumberOfDays()
        {
            // Arrange
            int days = 1000;

            // Act
            var result = _controller.GetAverageTemperature(days);

            // Assert
            result.Should().BeInRange(-20, 55);
        }

        // Test 8 - Route 4 GetHottestDay, One day -> Hottest day
        [Fact]
        public void WeatherForecastController_GetHottestDay_SingleDayReturnsWeatherForecastForThatDay()
        {
            // Arrange
            int days = 1;
            var expectedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

            // Act
            var result = _controller.GetHottestDay(days);

            // Assert
            result.Date.Should().Be(expectedDate);
        }
    }
}
// DONE:
// Case that fails: Test 3, Test 6
// Edge cases: Test 4, Test 5

// Question: How is the % of test coverage calculated?

