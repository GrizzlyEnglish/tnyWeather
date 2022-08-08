using System.Text.Json.Serialization;

namespace tnyWeather.Shared;

public class OpenWeatherResult
{
    public Weather[] Weather { get; set; }
    [JsonIgnore]
    public ErrorResult Error { get; set; }
}

public class Weather
{
    public int Id { get; set; }
    public string Main { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
}