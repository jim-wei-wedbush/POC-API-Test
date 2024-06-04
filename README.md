# POC Simple API Test

A simple API Test POC implementation using ASP.NET Core API, and a corresponding xUnit test project.

## Project Notes:

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

## Result:
- Test passed successfully in 971ms.


## Learnings:
- Project references can be used to establish dependencies between projects within a Visual Studio solution. 
- Test project can reference the API project to access its types and models without redefining.
- AAA pattern - Arrange-Act-Assert; Keeps test methods readable and maintainable.
- Visual Studio and Windows environment is much more compatible with .NET and C#.
- Familarized myself with Visual Studio and its differences to VSCode.