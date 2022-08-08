using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tnyWeather.Managers;
using tnyWeather.Shared.Contracts;

namespace tnyWeather.Tests.ManagerTests;

[TestFixture]
public class WeatherManagerTests
{
    private WeatherManager weatherManager;
    private Mock<IWeatherAccessor> mockWeatherAccessor;
    private Mock<IWeatherEngine> mockWeatherEngine;

    [SetUp]
    public void Init()
    {
        mockWeatherEngine = new Mock<IWeatherEngine>();
        mockWeatherAccessor = new Mock<IWeatherAccessor>();

        weatherManager = new WeatherManager(mockWeatherAccessor.Object, mockWeatherEngine.Object);
    }

    [Test]
    public async Task FetchWeather_Invalid_Parmas()
    {
        var results = await weatherManager.FetchWeather("", "", null, null);
        results.Error.Error.ShouldBe(WeatherManager.INVALID_PARAMS);
    }

    [Test]
    public async Task FetchWeather_ByCity()
    {
        var city = "Louisville";
        mockWeatherEngine
            .Setup(s => s.ValidateGeolocationParams(It.Is<string>(p => p == city), It.Is<string>(p => p == "")))
            .Returns(true);

        var results = await weatherManager.FetchWeather(city, "", null, null);

        mockWeatherAccessor.Verify(s => s.FetchWeatherByCity(It.Is<string>(p => p == city)));
    }

    [Test]
    public async Task FetchWeather_ByZip()
    {
        var zip = "40228";
        mockWeatherEngine
            .Setup(s => s.ValidateGeolocationParams(It.Is<string>(p => p == ""), It.Is<string>(p => p == zip)))
            .Returns(true);

        var results = await weatherManager.FetchWeather("", zip, null, null);

        mockWeatherAccessor.Verify(s => s.FetchWeatherByZip(It.Is<string>(p => p == zip)));
    }

    [Test]
    public async Task FetchWeather_ByCoords()
    {
        var results = await weatherManager.FetchWeather("", "", 10.2, 30.3);

        mockWeatherAccessor.Verify(s => s.FetchWeather(It.Is<double>(p => p == 10.2), It.Is<double>(p => p == 30.3)));
    }
}
