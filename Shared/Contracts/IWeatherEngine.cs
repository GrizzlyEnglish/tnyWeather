using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tnyWeather.Shared.Contracts;

public interface IWeatherEngine
{
    bool ValidateGeolocationParams(string cityCode, string zipCode);
}
