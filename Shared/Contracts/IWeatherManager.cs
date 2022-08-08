namespace tnyWeather.Shared.Contracts;

public interface IWeatherManager
{
    Task<OpenWeatherResult> FetchWeather(string cityName, string zipCode, double? latitude, double? longitude);
}