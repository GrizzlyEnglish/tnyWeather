using System.Net.Http.Json;
using tnyWeather.Shared;
using tnyWeather.Shared.Contracts;

namespace tnyWeather.Accessors;

public class WeatherAccessor : IWeatherAccessor
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherAccessor(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("OpenWeatherClient");
        _apiKey = Environment.GetEnvironmentVariable("OPEN_WEATHER_API_KEY");
        if (_apiKey == null)
        {
            throw new Exception("Mising api key for open weather");
        }
    }

    public async Task<OpenWeatherResult> FetchWeather(double lat, double lon)
    {
        return await _httpClient.GetFromJsonAsync<OpenWeatherResult>($"/data/2.5/weather?lat={lat}&lon={lon}&appid={_apiKey}");
    }

    public async Task<OpenWeatherResult> FetchWeatherByCity(string cityName)
    {
        return await _httpClient.GetFromJsonAsync<OpenWeatherResult>($"/data/2.5/weather?q={cityName}&appid={_apiKey}");
    }

    public async Task<OpenWeatherResult> FetchWeatherByZip(string zipCode)
    {
        return await _httpClient.GetFromJsonAsync<OpenWeatherResult>($"/data/2.5/weather?zip={zipCode}&appid={_apiKey}");
    }

}
