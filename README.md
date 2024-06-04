# POC Simple API Test

A simple API Test POC implementation using ASP.NET Core API, and a corresponding xUnit test project.

## Project Notes:

- Used default WeatherForecastController class
- Added GET route to WeatherForecastController
- Added xUnit test project and API project reference
- Created WeatherForecastControllerTests class, and test method Get_ReturnsWeatherForecasts(), using AAA
- Created test method GetByDays_ReturnsWeatherForecastsForSpecifiedDays(), using AAA


## Route 1:
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
- Test passed successfully.

## Route 2:
### Arrange:
- In test method, created mock instance of ILogger<WeatherForecastController>
- Initialized int days

### Act:
- Called GET method of WeatherForecastController with int parameter {days}, retrieved weather forecasts.

### Assert:
- Verified result is:
	1. All of the above for Route 1
	1. Length of results array is equal to {days} parameter


## Learnings:
- Project references can be used to establish dependencies between projects within a Visual Studio solution. 
- Test project can reference the API project to access its types and models without redefining.
- AAA pattern - Arrange-Act-Assert; Keeps test methods readable and maintainable.
- Visual Studio and Windows environment is much more compatible with .NET and C#.
- Familiarized myself with Visual Studio and its differences to VSCode.