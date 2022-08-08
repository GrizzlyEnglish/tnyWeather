using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tnyWeather.Engines;

namespace tnyWeather.Tests.EngineTests;

[TestFixture]
public class WeatherEngineTests
{
    private WeatherEngine weatherEngine;

    [SetUp]
    public void Init()
    {
        weatherEngine = new WeatherEngine();
    }

    [Test]
    [TestCase("Louisville", "")]
    [TestCase("", "40228")]
    public void ValidateGeolocationParams_Valid(string city, string zip)
    {
        weatherEngine.ValidateGeolocationParams(city, zip);
    }

    [Test]
    [TestCase("Louisville", "hsakjlfhjasd")]
    [TestCase("", "")]
    public void ValidateGeolocationParams_InValid(string city, string zip)
    {
        weatherEngine.ValidateGeolocationParams(city, zip);
    }
}
