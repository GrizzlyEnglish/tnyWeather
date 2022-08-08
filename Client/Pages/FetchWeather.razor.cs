using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using tnyWeather.Shared;

namespace tnyWeather.Client.Pages;

public partial class FetchWeather : ComponentBase
{
    [Inject]
    private HttpClient httpClient { get; set; }

    public string CityName { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Lat { get; set; } = string.Empty;
    public string Lon { get; set; } = string.Empty;

    public bool ShowError { get; set; } = false;

    public OpenWeatherResult Weather { get; set; }

    public async Task Fetch()
    {
        var isCoords = !string.IsNullOrEmpty(Lon) && !string.IsNullOrEmpty(Lat);
        var isCity = !string.IsNullOrEmpty(CityName);
        var isZip = !string.IsNullOrEmpty(ZipCode);

        ShowError = !isCity && !isZip && !isCoords;
        if (ShowError)
        {
            return; 
        }

        Weather = await httpClient.GetFromJsonAsync<OpenWeatherResult>($"/api/weather?cityName={CityName}&zipCode={ZipCode}&latitude={Lat}&longitude={Lon}");
    }
}