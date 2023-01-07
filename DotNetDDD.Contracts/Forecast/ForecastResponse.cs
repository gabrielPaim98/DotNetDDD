namespace DotNetDDD.Contracts.Forecast;

public record ForecastResponse(
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);