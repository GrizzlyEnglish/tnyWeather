using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using tnyWeather.Managers;
using tnyWeather.Shared.Contracts;
using tnyWeather.Accessors;
using tnyWeather.Engines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient("OpenWeatherClient", c => c.BaseAddress = new System.Uri(builder.Configuration["OpenWeather:URL"]));

builder.Services.AddScoped<IWeatherManager, WeatherManager>();
builder.Services.AddScoped<IWeatherAccessor, WeatherAccessor>();
builder.Services.AddSingleton<IWeatherEngine, WeatherEngine>();

    string port = Environment.GetEnvironmentVariable("PORT");

if (port != null)
{
    builder.WebHost.UseUrls("http://*:" + port);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
