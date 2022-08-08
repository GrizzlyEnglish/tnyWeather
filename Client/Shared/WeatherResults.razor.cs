using Microsoft.AspNetCore.Components;
using tnyWeather.Shared;

namespace tnyWeather.Client.Shared;

public partial class WeatherResults : ComponentBase
{
    [Parameter]
    public OpenWeatherResult Weather { get; set; }

    public string GetIcon()
    {
        var currentWeather = Weather.Weather.First();
        return $"http://openweathermap.org/img/wn/{currentWeather.Icon}.png";
    }
}
