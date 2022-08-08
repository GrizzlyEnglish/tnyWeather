using tnyWeather.Shared;
using tnyWeather.Shared.Contracts;

namespace tnyWeather.Managers;

public class WeatherManager : IWeatherManager
{
    public static string INVALID_PARAMS = "City name or zip code MUST be set if missing latitude and longitude";

    private readonly IWeatherAccessor _weatherAccessor;
    private readonly IWeatherEngine _weatherEngine;

    public WeatherManager(IWeatherAccessor weatherAccessor, IWeatherEngine weatherEngine)
    {
        _weatherAccessor = weatherAccessor;
        _weatherEngine = weatherEngine;
    }

    public async Task<OpenWeatherResult> FetchWeather(string cityName, string zipCode, double? latitude, double? longitude)
    {
        // If we don't have latitude and longitude we have to geolocate before getting the weather
        if (latitude == null || longitude == null)
        {
            if (!_weatherEngine.ValidateGeolocationParams(cityName, zipCode))
            {
                return new OpenWeatherResult
                {
                    Error = new ErrorResult
                    {
                        Error = INVALID_PARAMS
                    }
                };
            }

            return string.IsNullOrEmpty(cityName) ?
                await _weatherAccessor.FetchWeatherByZip(zipCode) :
                await _weatherAccessor.FetchWeatherByCity(cityName);
        }

        return await _weatherAccessor.FetchWeather(latitude.Value, longitude.Value);
    }
}
