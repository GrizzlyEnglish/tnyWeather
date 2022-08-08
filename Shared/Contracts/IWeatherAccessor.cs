using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tnyWeather.Shared.Contracts;

public interface IWeatherAccessor
{
    Task<OpenWeatherResult> FetchWeather(double lat, double lon);
    Task<OpenWeatherResult> FetchWeatherByZip(string zipCode);
    Task<OpenWeatherResult> FetchWeatherByCity(string cityName);
}
