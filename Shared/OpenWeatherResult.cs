using System.Text.Json.Serialization;

namespace tnyWeather.Shared;

public class OpenWeatherResult
{
    public Weather[] Weather { get; set; }
    public Main Main { get; set; }
    public Wind Wind { get; set; }

    public string Name { get; set; }

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

public class Main 
{
    public double Temp { get; set; }
    public double Feels_Like { get; set; }
}

public class Wind
{
    public double Speed { get; set; }
}