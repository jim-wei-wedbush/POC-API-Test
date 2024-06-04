# POC Simple API Test

A simple API Test POC implementation using ASP.NET Core API, and a corresponding xUnit test project.

## Notes:

- Used default WeatherForecastController class
- Added xUnit test project and API project reference
- Created WeatherForecastControllerTests class, and test method Get_ReturnsWeatherForecasts(), using AAA

### Arrange:
- In test method, created mock instance of ILogger<WeatherForecastController>

### Act:
- Called GET method of WeatherForecastController, retrieved weather forecasts.

### Assert:
- Verified the result is:
	1. Not null
	2. Assignable from IEnumerable<WeatherForecast>
	1. Not empty