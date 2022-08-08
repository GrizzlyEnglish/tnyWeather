using System.Text.RegularExpressions;
using tnyWeather.Shared.Contracts;

namespace tnyWeather.Engines;

public class WeatherEngine : IWeatherEngine
{
    private readonly string ZIP_REGEX = "^\\d{5}(?:[-\\s]\\d{4})?$";

    public bool ValidateGeolocationParams(string cityName, string zipCode)
    {
        return cityName != null || (zipCode != null && Regex.IsMatch(zipCode, ZIP_REGEX));
    }
}