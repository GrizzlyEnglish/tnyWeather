using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tnyWeather.Shared;
using tnyWeather.Shared.Contracts;

namespace tnyWeather.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherManager _weatherManager;

        public WeatherController(IWeatherManager weatherManager)
        {
            _weatherManager = weatherManager;
        }

        public async Task<IActionResult> Get([FromQuery] double? longitude = null, [FromQuery] double? latitude = null, [FromQuery] string? cityName = null, [FromQuery] string? zipCode = null)
        {
            var weather = await _weatherManager.FetchWeather(cityName, zipCode, latitude, longitude);
            if (weather == null || weather.Error != null)
            {
                return Problem(weather?.Error.Error ?? "Something went wrong please try again");
            }

            return Ok(weather);
        }
    }
}
